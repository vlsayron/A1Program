using System;
using System.Configuration;
using ConsoleBcl.Models;
using ConsoleBcl.Models.Configuration;
using ConsoleBcl.Models.Localization;

namespace ConsoleBcl
{
    class Program
    {
        private static LocalizationSettingsBase _localization;
        private static CustomConfigurationSection _configuration;

        static void Main()
        {
            _configuration = (CustomConfigurationSection)ConfigurationManager.GetSection("customSection");
            var cultureInfo = _configuration.Localization.Localization;
            _localization = LocalizationProvider.GetLocalization(cultureInfo);

            var watcher = new FileWatcher(_configuration.RulesForFolders, _configuration.TargetFolder,
                _configuration.DefaultFolder);

            watcher.FileCreated += delegate(string fileName)
            {
                Log(string.Format(_localization.FileIsCreated(), fileName));
            };
            watcher.FileDeleted += delegate(string fileName)
            {
                Log(string.Format(_localization.FileIsDeleted(), fileName));
            };
            watcher.FileRenamed += delegate (string oldName, string newName)
            {
                Log(string.Format(_localization.FileIsRenamed(), oldName, newName));
            };
            watcher.FileRuleFound += delegate(string fileName)
            {
                Log(string.Format(_localization.FoundRule(), fileName)); 

            };
            watcher.FileRuleNotFound += delegate(string fileName)
            {
                Log(string.Format(_localization.NotFoundRule(), fileName));
            };

            do
            {
                Console.Clear();
                Console.WriteLine(_localization.Info());
                Console.WriteLine();
                Console.Write(_localization.ToExit());
                Console.WriteLine();
            } while (Console.ReadKey().KeyChar != 'q');
        }


        private static void Log(string message)
        {
            var date = DateTime.Now;
            var culture = _localization.CultureInfo;

            Console.WriteLine($@"{date.ToString("dd MMMM hh:mm:ss", culture)}- {message}");
        }

    }
}
