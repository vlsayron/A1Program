using System;
using System.Globalization;

namespace ConsoleBcl.Models.Localization
{
    abstract class LocalizationProvider
    {
        public static LocalizationSettingsBase GetLocalization(CultureInfo cultureInfo)
        {
            switch (cultureInfo.Name)
            {
                case "ru":
                    return new LocalizationSettingsRussian(cultureInfo);
                case "en":
                    return new LocalizationSettingsEnglish(cultureInfo);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
