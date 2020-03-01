using System.Configuration;

namespace ConsoleBcl.Models.Configuration.ForTest2
{
    public class RuleElement : ConfigurationElement
    {
        [ConfigurationProperty("folder", IsKey = true)]
        public string Folder
        {
            get { return (string)base["folder"]; }
        }

        [ConfigurationProperty("fileFilter")]
        public string FileFilter
        {
            get { return (string)base["fileFilter"]; }
        }
        [ConfigurationProperty("addNumber")]
        public string AddNumber
        {
            get { return (string)base["addNumber"]; }
        }
        [ConfigurationProperty("addDate")]
        public string AddDate
        {
            get { return (string)base["addDate"]; }
        }
    }
}
