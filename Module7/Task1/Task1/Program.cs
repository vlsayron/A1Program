using System;
using WebGrabber;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            const string address = "https://dev.by/";
            const bool verboseMode = true;
            const string folderPath = @"C:\_WebGrabberResult\";
            const int depth = 2;
            const GrabberModeEnum domainMode = GrabberModeEnum.AllDomains;
            var allowedFiles = new[] {"html", "jpg", "gif"};

            var grabber = new Grabber(address, folderPath, depth, verboseMode,  domainMode, allowedFiles);

            grabber.GrabberEvent += Console.WriteLine;

            grabber.Start();

            Console.WriteLine("Finish! Press any key");
            Console.ReadKey();
        }


    }
}
