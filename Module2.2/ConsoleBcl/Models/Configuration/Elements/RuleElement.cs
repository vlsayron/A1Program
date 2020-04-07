using System.Configuration;

namespace ConsoleBcl.Models.Configuration.Elements
{
    class RuleElement : ConfigurationElement
    {
        [ConfigurationProperty("folder", IsKey = true, IsRequired = false)]
        public string Folder => (string)base["folder"];

        [ConfigurationProperty("fileFilter", IsRequired = true)]
        public string FileFilter => (string)base["fileFilter"];

        [ConfigurationProperty("addNumber", IsRequired = false, DefaultValue = false)]
        public bool AddNumber => (bool)base["addNumber"];

        [ConfigurationProperty("addDate", IsRequired = false, DefaultValue = false)]
        public bool AddDate => (bool)base["addDate"];
    }
}
