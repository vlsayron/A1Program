using System;
using NuGet.Package.BL;
using NuGet.Package.Models;


namespace MainApp
{
    class Program
    {
        static void Main()
        {
            const string fileName = @"car.txt";

            var car = new Car { Id = 1, Name = "Audi" };

            var carJson = CarSerialization.CarToJson(car);
            CarFileRepository.WriteJson(fileName, carJson);

            carJson = CarFileRepository.ReadJson(fileName);

            car = CarSerialization.JsonToCar(carJson);

            Console.WriteLine($"{car.Id} - {car.Name}");

            Console.WriteLine("Done");
            Console.ReadKey();

        }
    }
}
