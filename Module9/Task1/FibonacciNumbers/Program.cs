using System;
using FibonacciNumbers.Cache;

namespace FibonacciNumbers
{
    class Program
    {
        static IFibonacciCache _fibonacciCache = new FibonacciCache();

        static void Main()
        {
            const int minValue = 3;
            const int maxValue = 100;

            while (true)
            {
                Console.Write("How many fibonacci numbers do you need to print: ");
               
                if (!int.TryParse(Console.ReadLine(), out var fibonacciNumber))
                {
                    Console.WriteLine("Need to enter an integer");
                    continue;
                }

                if (fibonacciNumber > maxValue || fibonacciNumber < minValue)
                {
                    Console.WriteLine($"Need to enter an integer in the range [{minValue}-{maxValue}]");
                    continue;
                }

                var fibonacciResult = _fibonacciCache.GetFibonacciNumber(fibonacciNumber);
                
                if (fibonacciResult == null)
                {
                    fibonacciResult = GetFibonacciNumber(fibonacciNumber);
                    Console.Write("Calculated result: ");
                }
                else
                {
                    Console.Write("Cache result: ");
                }
                
                var result = fibonacciResult.ConvertToList();

                foreach (var number in result)
                {
                    Console.Write($"{number.Value} ");
                }

                Console.WriteLine();
            }
        }

        static FibonacciNumber GetFibonacciNumber(int index)
        {
            var maxFibonacci = _fibonacciCache.GetPreviousLargest(index);

            var newFibonacci = new FibonacciNumber()
            {
                Index = maxFibonacci.Index + 1,
                Value = maxFibonacci.Value + maxFibonacci.PreviousValue.Value,
                PreviousValue = maxFibonacci
            };

            while (newFibonacci.Index < index)
            {
                var tempValue = new FibonacciNumber()
                {
                    Index = newFibonacci.Index + 1,
                    Value = newFibonacci.Value + newFibonacci.PreviousValue.Value,
                    PreviousValue = newFibonacci
                };

                _fibonacciCache.AddNewValue(tempValue);

                newFibonacci = tempValue;
            }

            _fibonacciCache.AddNewValue(newFibonacci);

            return newFibonacci;
        }

    }
}
