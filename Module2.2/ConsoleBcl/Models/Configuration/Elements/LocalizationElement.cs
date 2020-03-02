using System.Configuration;
using System.Globalization;

namespace ConsoleBcl.Models.Configuration.Elements
{ 
    class LocalizationElement : ConfigurationElement
    {
        [ConfigurationProperty("value")]
        public CultureInfo Localization => (CultureInfo)this["value"];
    }
}
