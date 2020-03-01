using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using ConsoleBcl.Models;
using ConsoleBcl.Models.Configuration;
using ConsoleBcl.Models.Configuration.ForTest2;
using ConsoleBcl.Models.Localisation;

namespace ConsoleBcl
{
    class Program
    {
        private static LocalizationSettingsBase _localization;
        private static CustomConfigurationSection _configuration;

        static void Main(string[] args)
        {
            _configuration = (CustomConfigurationSection)ConfigurationManager.GetSection("customSection");
            var cultureInfo = _configuration.Localisation.Localisation;
            _localization = LocalizationProvider.GetLocalization(cultureInfo);

            var listWatchers = new List<FileSystemWatcher>();

            foreach (RuleElement item in _configuration.RulesForFolders)
            {
                listWatchers.Add(new FileSystemWatcher(item.Folder));
            }


            do
            {
                foreach (var watcher in listWatchers)
                {
                    watcher.NotifyFilter = NotifyFilters.FileName;

                    watcher.Filter = "*";

                    watcher.Created += OnCreated;
                    watcher.Deleted += OnDeleted;
                    watcher.Renamed += OnRenamed;

                    watcher.EnableRaisingEvents = true;
                }

                Console.Clear();
                Console.WriteLine(_localization.Info());
                Console.WriteLine();
                Console.WriteLine(_localization.ToExit());
                Console.WriteLine();

            } while (Console.Read() != 'q');
        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            Console.WriteLine(string.Format(_localization.FileIsCreated(), e.FullPath));
        }
        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
            Console.WriteLine(string.Format(_localization.FileIsDeleted(), e.FullPath));
        }
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine(string.Format(_localization.FileIsRenamed(), e.OldFullPath, e.FullPath));
            Process(source, e);
        }


        private static void Process(object source, FileSystemEventArgs e)
        {
            var file = e.FullPath;

            var folder = Path.GetDirectoryName(e.FullPath);
            var expressions = _configuration.RulesForFolders.GetRuleElement(folder).FileFilter;

            var newFolder = string.Empty;

            if (Regex.IsMatch(file, expressions, RegexOptions.IgnoreCase))
            {

                newFolder = _configuration.TargetFolder.FolderPath + file.Substring(file.LastIndexOf('\\') + 1);
                Log(_localization.FoundRule());
            }
            else
            {
                newFolder = _configuration.DefaultFolder.FolderPath + file.Substring(file.LastIndexOf('\\') + 1);
                Log(_localization.NotFoundRule());
            }

            File.Move(file, newFolder);

        }



        private static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
