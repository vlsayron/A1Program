using ConsoleBcl.Models.Configuration.Elements;
using ConsoleBcl.Models.Configuration.ForTest2;
using ConsoleBcl.Models;
using System.Configuration;

namespace ConsoleBcl.Models.Configuration
{
    public class CustomConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("appName")]
        public string ApplicationName
        {
            get { return (string)base["appName"]; }
        }

        [ConfigurationProperty("localisation")]
        public LocalisationElement Localisation
        {
            get { return (LocalisationElement)this["localisation"]; }
        }

        [ConfigurationProperty("targetFolder")]
        public FolderElement TargetFolder
        {
            get { return (FolderElement)this["targetFolder"]; }
        }

        [ConfigurationProperty("defaultFolder")]
        public FolderElement DefaultFolder
        {
            get { return (FolderElement)this["defaultFolder"]; }
        }


        [ConfigurationProperty("rulesForFolders")]
        public RuleElementCollection RulesForFolders
        {
            get { return (RuleElementCollection)this["rulesForFolders"]; }
        }


    }
}
