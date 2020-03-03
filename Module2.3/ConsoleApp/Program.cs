using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            const string exit = "exit";

            Console.WriteLine("This program prints the first character of each input line");
            Console.WriteLine($"Print '{exit}' for exit");

            do
            {
                try
                {
                    var userString = Console.ReadLine();

                    if (userString != null && exit.Equals(userString.ToLower()))
                    {
                        break;
                    }

                    var firstChar = GetFirstChar(userString);

                    Console.WriteLine($"First char: '{firstChar}', string: '{userString}'");
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (true);
        }

        private static char GetFirstChar(string userString)
        {
            if (string.IsNullOrEmpty(userString))
            {
                throw new ArgumentNullException(nameof(userString), "The string cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(userString))
            {
                throw new ArgumentException("The string must consist of at least one non-empty character", nameof(userString));
            }

            return userString[0];
        }
    }
}
