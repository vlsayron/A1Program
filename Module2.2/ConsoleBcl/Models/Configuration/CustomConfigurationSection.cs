using ConsoleBcl.Models.Configuration.Elements;
using System.Configuration;

namespace ConsoleBcl.Models.Configuration
{
    class CustomConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("appName")]
        public string ApplicationName => (string)base["appName"];

        [ConfigurationProperty("localization")]
        public LocalizationElement Localization => (LocalizationElement)this["localization"];
        [ConfigurationProperty("processExistingFiles")]
        public ProcessExistingFilesElement ProcessExistingFiles => (ProcessExistingFilesElement)this["processExistingFiles"];

        [ConfigurationProperty("targetFolder")]
        public FolderElement TargetFolder => (FolderElement)this["targetFolder"];

        [ConfigurationProperty("defaultFolder")]
        public FolderElement DefaultFolder => (FolderElement)this["defaultFolder"];

        [ConfigurationProperty("rulesForFolders")]
        public RuleElementCollection RulesForFolders => (RuleElementCollection)this["rulesForFolders"];
    }
}
