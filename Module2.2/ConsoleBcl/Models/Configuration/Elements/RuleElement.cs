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
        public string AddNumber => (string)base["addNumber"];

        [ConfigurationProperty("addDate")]
        public string AddDate => (string)base["addDate"];
    }
}
