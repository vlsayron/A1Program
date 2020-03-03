using System.Configuration;

namespace ConsoleBcl.Models.Configuration.Elements
{
    class FolderElement : ConfigurationElement
    {
        [ConfigurationProperty("path")]
        public string FolderPath => (string)this["path"];
    }
}
