using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using ConsoleBcl.Models.Configuration.Elements;

namespace ConsoleBcl.Models
{
    delegate void WatcherHandler(string fineName);
    delegate void FileRenamedHandler(string oldName, string newName);
    delegate void FileRule(string fileName);

    class FileWatcher
    {
        public event WatcherHandler FileCreated;
        public event WatcherHandler FileDeleted;
        public event FileRenamedHandler FileRenamed;
        public event FileRule FileRuleFound;
        public event FileRule FileRuleNotFound;

        private int _serialNumber;
        private readonly RuleElementCollection _ruleCollection;
        private readonly FolderElement _targetFolder;
        private readonly FolderElement _defaultFolder;

        public FileWatcher(RuleElementCollection ruleCollection, FolderElement targetFolder, FolderElement defaultFolder)
        {
            _serialNumber = 1;
            _ruleCollection = ruleCollection;
            _targetFolder = targetFolder;
            _defaultFolder = defaultFolder;

            var watchers = new List<FileSystemWatcher>();

            foreach (RuleElement item in ruleCollection)
            {
                var watcher = new FileSystemWatcher(item.Folder)
                {
                    NotifyFilter = NotifyFilters.FileName,
                    Filter = "*",
                    EnableRaisingEvents = true
                };

                watcher.Renamed += OnRenamed;
                watcher.Created += OnCreated;
                watcher.Deleted += OnDeleted;

                watchers.Add(watcher);
            }
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            FileRenamed?.Invoke(e.OldName, e.Name);
            ProcessFile(e.FullPath);
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            FileCreated?.Invoke(e.Name);
            ProcessFile(e.FullPath);
        }

        private void OnDeleted(object source, FileSystemEventArgs e)
        {
            FileDeleted?.Invoke(e.Name);
        }
       

        private void ProcessFile(string fileFullName)
        {
            var fileName = Path.GetFileName(fileFullName);
            var fileFolder = Path.GetDirectoryName(fileFullName);

            var filter = _ruleCollection.GetRuleElement(fileFolder);
            var newFileName = fileName;

            string newFolder;
            if (Regex.IsMatch(fileName, filter.FileFilter, RegexOptions.IgnoreCase))
            {
                newFolder = _targetFolder.FolderPath;
                FileRuleFound?.Invoke(fileName);
            }
            else
            {
                newFolder = _defaultFolder.FolderPath;
                FileRuleNotFound?.Invoke(fileName);
            }

            if (filter.AddDate)
            {
                var currentCulture = Thread.CurrentThread.CurrentCulture;
                newFileName = $@"{DateTime.Now.ToString("dd MMMM hh:mm:ss ", currentCulture)}-{newFileName}";
            }

            if (filter.AddNumber)
            {
                newFileName = $@"N{_serialNumber}-{newFileName}";
                _serialNumber++;
            }

            var fullNewFileName = Path.Combine(newFolder, newFileName);

            while (File.Exists(fullNewFileName))
            {
                var newName = string.Concat(Path.GetFileNameWithoutExtension(fullNewFileName), "1");
                var fileExtension = Path.GetExtension(fullNewFileName);
                fullNewFileName = Path.Combine(newFolder, string.Concat(newName, fileExtension));
            }

            File.Move(fileFullName, fullNewFileName);
        }

      

       

       
    }
}
