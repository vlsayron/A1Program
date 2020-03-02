using System.Globalization;
using System.Resources;

namespace ConsoleBcl.Models.Localization
{
    abstract class LocalizationSettingsBase
    {
        private readonly ResourceManager _resourceManager;
        public  CultureInfo CultureInfo { get; }

        protected LocalizationSettingsBase(CultureInfo cultureInfo, string fileResources)
        {
            _resourceManager = new ResourceManager(fileResources, typeof(Program).Assembly);
            CultureInfo = cultureInfo;
        }

        public string Info()
        {
            return _resourceManager.GetString("Info");
        }

        public string ToExit()
        {
            return _resourceManager.GetString("ToExit");
        }

      

        public string FoundRule()
        {
            return _resourceManager.GetString("FoundRule");
        }

        public string NotFoundRule()
        {
            return _resourceManager.GetString("NotFoundRule");
        }
        public string ExistingFile()
        {
            return _resourceManager.GetString("ExistingFile");
        }
        public string FileIsCreated()
        {
            return _resourceManager.GetString("FileIsCreated");
        }

        public string FileIsDeleted()
        {
            return _resourceManager.GetString("FileIsDeleted");
        }
        public string FileIsRenamed()
        {
            return _resourceManager.GetString("FileIsRenamed");
        }




        


    }
}
