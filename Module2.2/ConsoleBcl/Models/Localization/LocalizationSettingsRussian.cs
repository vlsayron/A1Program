using System.Globalization;

namespace ConsoleBcl.Models.Localization
{
    class LocalizationSettingsRussian : LocalizationSettingsBase
    {
        public LocalizationSettingsRussian(CultureInfo cultureInfo)
            : base(cultureInfo, "ConsoleBcl.Properties.Resources-RU")
        {

        }
    }
}
