using Newtonsoft.Json;
using NuGet.Package.Models;

namespace NuGet.Package.BL
{
    public static class CarSerialization
    {
        public static Car JsonToCar(string json)
        {
            return JsonConvert.DeserializeObject<Car>(json);
        }

        public static string CarToJson(Car car)
        {
            return JsonConvert.SerializeObject(car);
        }
    }
}
