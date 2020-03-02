using System.Globalization;

namespace ConsoleBcl.Models.Localization
{
    class LocalizationSettingsEnglish : LocalizationSettingsBase
    {
        public LocalizationSettingsEnglish(CultureInfo cultureInfo) 
            : base(cultureInfo, "ConsoleBcl.Properties.Resources")
        {

        }
    }
}
