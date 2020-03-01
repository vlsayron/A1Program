using System.Globalization;

namespace ConsoleBcl.Models.Localisation
{
    class LocalizationSettingsEnglish : LocalizationSettingsBase
    {
        public LocalizationSettingsEnglish(CultureInfo cultureInfo) 
            : base(cultureInfo, "ConsoleBcl.Properties.Resources")
        {

        }
    }
}
