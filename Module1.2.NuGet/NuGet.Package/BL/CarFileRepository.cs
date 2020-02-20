using System.IO;
using System.Text;
using NuGet.Package.Models;

namespace NuGet.Package.BL
{
    public static class CarFileRepository
    {
        public static bool WriteJson(string fileName, string content)
        { 
            using (var sw = new StreamWriter(fileName, false, Encoding.Default))
            {
                sw.WriteLine(content);
            }

            return true;
        }

        public static bool Write(string fileName, Car car)
        {
            var content = CarSerialization.CarToJson(car);
            using (var sw = new StreamWriter(fileName, false, Encoding.Default))
            {
                sw.WriteLine(content);
            }

            return true;
        }

        public static string ReadJson(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                return sr.ReadToEnd();
            }
        }

        public static Car Read(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                var json = sr.ReadToEnd();
                return CarSerialization.JsonToCar(json);
            }
        }
    }
}
