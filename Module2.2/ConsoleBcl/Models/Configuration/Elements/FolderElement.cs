using System.Configuration;

namespace ConsoleBcl.Models.Configuration.Elements
{
    class FolderElement : ConfigurationElement
    {
        [ConfigurationProperty("value")]
        public string FolderPath => (string)this["value"];
    }
}
