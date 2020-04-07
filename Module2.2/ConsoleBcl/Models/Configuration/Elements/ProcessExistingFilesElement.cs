using System.Configuration;

namespace ConsoleBcl.Models.Configuration.Elements
{
    class ProcessExistingFilesElement : ConfigurationElement
    {
        [ConfigurationProperty("process", IsRequired = false, DefaultValue = false)]
        public bool Process => (bool)this["process"];
    }
}
