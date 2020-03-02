using System.Configuration;

namespace ConsoleBcl.Models.Configuration.Elements
{
    class RuleElement : ConfigurationElement
    {
        [ConfigurationProperty("folder", IsKey = true)]
        public string Folder => (string)base["folder"];

        [ConfigurationProperty("fileFilter")]
        public string FileFilter => (string)base["fileFilter"];

        [ConfigurationProperty("addNumber")]
        public bool AddNumber => (bool)base["addNumber"];

        [ConfigurationProperty("addDate")]
        public bool AddDate => (bool)base["addDate"];
    }
}
