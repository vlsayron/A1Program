using System.Configuration;
using System.Globalization;

namespace ConsoleBcl.Models.Configuration.Elements
{ 
    public class LocalisationElement : ConfigurationElement
    {
        [ConfigurationProperty("value")]
        public CultureInfo Localisation
        {
            get { return (CultureInfo)this["value"]; }
        }
    }
}
