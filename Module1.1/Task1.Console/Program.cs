using System;
using System.Linq;
using Task2.Library;

namespace Task1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            if (args.Length == 0)
            {
                System.Console.WriteLine("Name was not passed through command line parameter");
                System.Console.Write("Enter your name: ");
                name = System.Console.ReadLine();
            }
            else
            {
                System.Console.WriteLine("Name derived from command line options");
                name = args.FirstOrDefault();
            }


            System.Console.WriteLine($"{WelcomeUser.Welcome(name)}");
            System.Console.WriteLine("Press any key to close the application");
            System.Console.ReadKey();
        }
    }
}
