using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using CsQuery;

namespace WebGrabber
{
    public class Grabber
    {
        private readonly string _resourceAddress;
        private readonly string _localPath;
        private readonly int _depth;
        private readonly bool _verbose;
        private readonly GrabberModeEnum _domainMode;
        private readonly IEnumerable<string> _allowedFiles;

        private const string RouteFileName = "index.html";
        private readonly string[] _allowedSchemes = { "http", "https" };

        public event GrabberHandler GrabberEvent;

        public Grabber(string resourceAddress, string localPath, int depth, bool verbose,  GrabberModeEnum domainMode, IEnumerable<string> allowedFiles)
        {
            _resourceAddress = resourceAddress;
            _localPath = localPath;
            _depth = depth;
            _verbose = verbose;
            _domainMode = domainMode;
            _allowedFiles = allowedFiles;
        }

        public void Start()
        {
            Directory.CreateDirectory(_localPath);

            var resourceAddress = new Uri(_resourceAddress);

            GetResources(_resourceAddress, resourceAddress, _localPath, _depth);
        }

        private void GetResources(string resourceAddress, Uri parentHost, string targetPath, int depth)
        {
            Uri resourceUri;

            try
            {
                resourceUri = new Uri(resourceAddress);

                if (!_allowedSchemes.Contains(resourceUri.Scheme))
                {
                    return;
                }
            }
            catch (Exception)
            {
                OnGrabberEvent($"'{resourceAddress}' isn't URL");
                return;
            }

            OnGrabberEvent($"Getting resource '{resourceAddress}'");
            
            HttpResponseMessage response;

            using (var client = new HttpClient())
            {
                response = client.GetAsync(resourceAddress).Result;
            }

            OnGrabberEvent($"'{resourceAddress}' is received");

            if (_allowedFiles == null ||
                _allowedFiles.Contains(Path.GetExtension(response.Content.Headers.ContentType.MediaType)))
            {
                return;
            }

            SaveResources(targetPath, response, resourceUri);

            if (depth == 0)
            {
                return;
            }

            depth--;

            var links = GetLinks(parentHost);
            
            foreach (var link in links)
            {
                GetResources(link, parentHost, Path.Combine(targetPath, resourceUri.Host), depth);
            }
        }

        
        private IEnumerable<string> GetLinks(Uri resource)
        {
            var links = new List<string>();
            
            var cq = CQ.CreateFromUrl(resource.ToString()).Find("a");

            foreach (var domObj in cq)
            {
                var link = domObj.GetAttribute("href");
               
                if (!Uri.IsWellFormedUriString(link, UriKind.Absolute))
                {
                    continue;
                }

                var linkUri = new Uri(link);
                
                switch (_domainMode)
                {
                    case GrabberModeEnum.OnlyCurrentDomain when !resource.Host.Equals(linkUri.Host):
                    case GrabberModeEnum.NotAboveCurrentDomain when !linkUri.Host.EndsWith(resource.Host):
                        continue;
                    case GrabberModeEnum.AllDomains:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                links.Add(link);
            }
            
            return links;
        }

        private void SaveResources(string targetPath, HttpResponseMessage source, Uri resourceUri)
        {
            var sourceStream = source.Content.ReadAsStreamAsync().Result;

            var fileName = resourceUri.Segments.Last();

            var directoryInfo = Directory.CreateDirectory(Path.Combine(targetPath, resourceUri.Host));

            if (Path.IsPathRooted(fileName))
            {
                fileName = RouteFileName;
            }

            var filePath = Path.Combine(directoryInfo.FullName, fileName.Replace("/", null));

            using (var fileStream = File.Open(filePath, FileMode.OpenOrCreate))
            {
                var buffer = new byte[1024];

                int length;

                while ((length = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, length);
                }
            }

            OnGrabberEvent($"File '{fileName}' has been saved");
        }

        private void OnGrabberEvent(string message)
        {
            if(_verbose)
            {
                GrabberEvent?.Invoke(message);
            }
        }
    }
}
