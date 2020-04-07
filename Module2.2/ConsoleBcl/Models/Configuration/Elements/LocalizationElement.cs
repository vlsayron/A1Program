using System.Configuration;
using System.Globalization;

namespace ConsoleBcl.Models.Configuration.Elements
{ 
    class LocalizationElement : ConfigurationElement
    {
        [ConfigurationProperty("culture")]
        public CultureInfo Localization => (CultureInfo)this["culture"];
    }
}
