using System;
using System.Collections.Generic;
using ParserLibrary;

namespace ConsoleAppTwo
{
    class Program
    {
        static void Main()
        {
            const string exit = "exit";

            Console.WriteLine("This program for convert strings to numbers");
            Console.WriteLine($"Print '{exit}' for exit");

            PrintTest();

            while (true)
            {
                Console.Write("Enter string: ");
                var userString = Console.ReadLine();

                if (userString != null && exit.Equals(userString.ToLower()))
                {
                    break;
                }

                Process(userString);
            }
        }


        static void Process(string sourceString)
        {
            var parser = new IntegerParser();

            Console.Write($"Source string: '{sourceString}', result: ");

            try
            {
                var result = parser.ConvertToInt(sourceString);
                Console.WriteLine($"{result}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"ArgumentException: {e.Message}");
            }
            catch (IncorrectFormatException e)
            {
                Console.WriteLine($"IncorrectFormatException: {e.Message}");
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"OverflowException: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }

        static void PrintTest()
        {
            Console.WriteLine("Demo:");
            var testList = new List<string>
            {
                "0",
                "12345",
                "-12345",
                int.MinValue.ToString(),
                int.MaxValue.ToString(),
                "",
                "   ",
                "qwerty",
                "12345678910",
                "--12345",
                "12-345",
                "-123-45",
                "-12345-",
                ((long) int.MinValue - 1).ToString(),
                ((long) int.MaxValue + 1).ToString(),
                "9876543210"
            };

            foreach (var testString in testList)
            {
                Process(testString);
            }

            Console.WriteLine();
        }
    }
}

