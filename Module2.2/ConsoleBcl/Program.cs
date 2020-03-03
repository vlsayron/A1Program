using System;
using System.Configuration;
using System.Globalization;
using System.Threading;
using ConsoleBcl.Models;
using ConsoleBcl.Models.Configuration;
using ConsoleBcl.Models.Configuration.Elements;
using localization = ConsoleBcl.Properties.Resources.LocalizationResources;

namespace ConsoleBcl
{
    class Program
    {

        static void Main()
        {
            var configuration = (CustomConfigurationSection)ConfigurationManager.GetSection("customSection");
            var cultureInfo = configuration.Localization.Localization;

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

           
            var watcher = new FileWatcher(configuration.RulesForFolders, configuration.TargetFolder,
                configuration.DefaultFolder);

            watcher.FileCreated += fileName => Log(string.Format(localization.FileIsCreated, fileName));
            watcher.FileRenamed += (oldName, newName) => Log(string.Format(localization.FileIsRenamed, oldName, newName));
            watcher.FileRuleFound += fileName => Log(string.Format(localization.FoundRule, fileName));
            watcher.FileRuleNotFound += fileName => Log(string.Format(localization.NotFoundRule, fileName));
            
            do
            {
                Console.Clear();
                Console.WriteLine(localization.ProgramInfo, GetProgramGoals(configuration.RulesForFolders));
                Console.Write(localization.ProgramExit);
                Console.WriteLine();
            } while (Console.ReadKey().KeyChar != 'q');
        }

        private static void Log(string message)
        {
            var date = DateTime.Now;
            var culture = Thread.CurrentThread.CurrentCulture;

            Console.WriteLine($@"{date.ToString("dd MMMM hh:mm:ss", culture)}- {message}");
        }

        private static string GetProgramGoals(RuleElementCollection ruleCollection)
        {
            var result = string.Empty;

            foreach (RuleElement rule in ruleCollection)
            {
                result += string.Format(localization.RuleDescription, rule.FileFilter, rule.Folder);

                if (rule.AddNumber)
                {
                    result += localization.RuleNeedAddSerialNumber;
                    if (rule.AddDate)
                    {
                        result += ", ";
                    }
                }

                if (rule.AddDate)
                {
                    result += localization.RuleNeedAddDate;
                }

                result += "\n";
            }


            return result;
        }

    }
}
