using System;
using System.Collections.Generic;

namespace SystemVisitor
{
    public delegate void VisitorLog(string message);

    public delegate bool VisitorFind(TreeElement element);

    public class FileSystemVisitor
    {
        public event VisitorLog Start;
        public event VisitorLog Finish;
        public event VisitorFind FileFinded;
        public event VisitorFind DirectoryFinded;
        public event VisitorFind FilteredFileFinded;
        public event VisitorFind FilteredDirectoryFinded;

        private readonly IFileDirectoryProvider _fileDirectoryProvider;
        private readonly string _path;
        private readonly Func<string, bool> _filter;
        private bool _shouldStop;
        private List<TreeElement> _allPath;

        public FileSystemVisitor(IFileDirectoryProvider fileDirectoryProvider, string path)
            : this(fileDirectoryProvider, path, param => true)
        {
        }

        public FileSystemVisitor(IFileDirectoryProvider fileDirectoryProvider, string path, Func<string, bool> filter)
        {
            _fileDirectoryProvider = fileDirectoryProvider;
            _path = path;
            _filter = filter;
        }


        public VisitorResult StartSearch()
        {
            Start?.Invoke("Start");

            _allPath = new List<TreeElement>();
            _allPath = ScanDirectory(_path);

            var result = new VisitorResult();

            foreach (var path in _allPath)
            {
                if (_filter(path.Path))
                {
                    if (path.Type == TreeElement.ElementType.Directory &&
                        FilteredDirectoryFinded != null && FilteredDirectoryFinded(path))
                    {
                        result.Add(path);
                    }

                    if (path.Type == TreeElement.ElementType.File &&
                        FilteredFileFinded != null && FilteredFileFinded(path))
                    {
                        result.Add(path);
                    }

                }
            }

            Finish?.Invoke("Finish");

            return result;
        }
        
        private List<TreeElement> ScanDirectory(string path)
        {
            var entities = _fileDirectoryProvider.GetFileSystemEntries(path);

            foreach (var entity in entities)
            {
                if (_shouldStop)
                {
                    return _allPath;
                }

                if (entity.Type == TreeElement.ElementType.Directory &&
                    DirectoryFinded != null && !DirectoryFinded.Invoke(entity))
                {
                    _shouldStop = true;
                }

                if (entity.Type == TreeElement.ElementType.File &&
                    FileFinded != null && !FileFinded.Invoke(entity))
                {
                    _shouldStop = true;
                }

                _allPath.Add(entity);

                if (entity.Type == TreeElement.ElementType.Directory)
                {
                    ScanDirectory(entity.Path);
                }

            }

            return _allPath;
        }

    }

}

