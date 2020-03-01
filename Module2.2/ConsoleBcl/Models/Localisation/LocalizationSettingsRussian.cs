using System.Globalization;

namespace ConsoleBcl.Models.Localisation
{
    class LocalizationSettingsRussian : LocalizationSettingsBase
    {
        public LocalizationSettingsRussian(CultureInfo cultureInfo)
            : base(cultureInfo, "ConsoleBcl.Properties.Resources-RU")
        {

        }
    }
}
