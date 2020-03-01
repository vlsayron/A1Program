using System.Configuration;

namespace ConsoleBcl.Models.Configuration.Elements
{
    public class FolderElement : ConfigurationElement
    {
        [ConfigurationProperty("value")]
        public string FolderPath
        {
            get { return (string)this["value"]; }
        }
    }
}
