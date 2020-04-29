using System.Collections.Generic;

namespace FibonacciNumbers
{
    static class FibonacciNumberExtensions
    {
        public static IEnumerable<FibonacciNumber> ConvertToList(this FibonacciNumber fibonacciNumber)
        {
            var tempList = new List<FibonacciNumber>();
            var number = fibonacciNumber;
            while (number != null)
            {
                tempList.Add(number);
                number = number.PreviousValue;
            }

            tempList.Reverse();

            return tempList;
        }
    }
}
