using Enumerable = System.Linq.Enumerable;

namespace FileHandler
{
    internal class FileRequest
    {
        public enum FileRequestTypeEnum
        {
            XmlDocument,
            ExcelDocument
        }

        public static FileRequestTypeEnum GetType(string type)
        {
            var excelTypes = new[] {"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"};
            var xmlTypes = new[] {"text/xml", "application/xml"};

            if (string.IsNullOrEmpty(type))
            {
                return FileRequestTypeEnum.ExcelDocument;
            }

            if (Enumerable.Any(excelTypes, type.Contains))
            {
                return FileRequestTypeEnum.ExcelDocument;
            }

            if (Enumerable.Any(xmlTypes, type.Contains))
            {
                return FileRequestTypeEnum.XmlDocument;
            }

            return FileRequestTypeEnum.ExcelDocument;
        }
    }
}