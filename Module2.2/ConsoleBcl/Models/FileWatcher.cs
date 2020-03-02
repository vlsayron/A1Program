using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using ConsoleBcl.Models.Configuration.Elements;

namespace ConsoleBcl.Models
{
    delegate void WatcherHandler(string message);

    delegate void FileRenamedHandler(string oldName, string newName);

    delegate void FileRule(string fileName);

    class FileWatcher
    {
        private readonly RuleElementCollection _ruleCollection;
        private readonly FolderElement _targetFolder;
        private readonly FolderElement _defaultFolder;

        public event WatcherHandler FileCreated;
        public event WatcherHandler FileDeleted;
        public event FileRenamedHandler FileRenamed;
        public event FileRule FileRuleFound;
        public event FileRule FileRuleNotFound;

        public FileWatcher(RuleElementCollection ruleCollection, FolderElement targetFolder, FolderElement defaultFolder)
        {
            _ruleCollection = ruleCollection;
            _targetFolder = targetFolder;
            _defaultFolder = defaultFolder;

            var listWatchers = new List<FileSystemWatcher>();

            //foreach (RuleElement item in ruleCollection)
            //{
            //    listWatchers.Add(new FileSystemWatcher(item.Folder));
            //}

            //foreach (var watcher in listWatchers)
            //{
            //    watcher.NotifyFilter = NotifyFilters.FileName;

            //    watcher.Filter = "*";

            //    watcher.Created += OnCreated;
            //    watcher.Deleted += OnDeleted;
            //    watcher.Renamed += OnRenamed;

            //    watcher.EnableRaisingEvents = true;
            //}

            foreach (RuleElement item in ruleCollection)
            {
                var watcher = new FileSystemWatcher(item.Folder)
                {
                    NotifyFilter = NotifyFilters.FileName,
                    Filter = "*",
                    EnableRaisingEvents = true
                };

                watcher.Created += OnCreated;
                watcher.Deleted += OnDeleted;
                watcher.Renamed += OnRenamed;

                listWatchers.Add(watcher);
            }

        }


        private void OnCreated(object source, FileSystemEventArgs e)
        {
            FileCreated?.Invoke(e.Name);
            Process(e.FullPath);
        }
        private void OnDeleted(object source, FileSystemEventArgs e)
        {
            FileDeleted?.Invoke(e.Name);
        }
        private void OnRenamed(object source, RenamedEventArgs e)
        {
            FileRenamed?.Invoke(e.OldName, e.Name);
            Process(e.FullPath);
        }

        private void Process(string filePath)
        {
            var fileName = filePath;

            var folder = Path.GetDirectoryName(filePath);
            var expressions = _ruleCollection.GetRuleElement(folder).FileFilter;

            string newFolder;

            if (Regex.IsMatch(fileName, expressions, RegexOptions.IgnoreCase))
            {
                newFolder = _targetFolder.FolderPath + fileName.Substring(fileName.LastIndexOf('\\') + 1);
                FileRuleFound?.Invoke(fileName);
            }
            else
            {
                newFolder = _defaultFolder.FolderPath + fileName.Substring(fileName.LastIndexOf('\\') + 1);
                FileRuleNotFound?.Invoke(fileName);
            }

            File.Move(fileName, newFolder);

        }

      

       

       
    }
}
