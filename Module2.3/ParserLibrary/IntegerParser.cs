using System;
using System.Numerics;

namespace ParserLibrary
{
    public class IntegerParser
    {
        public int ConvertToInt(string sourceString)
        {
            if (string.IsNullOrEmpty(sourceString))
            {
                throw new ArgumentException( "The string cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(sourceString))
            {
                throw new ArgumentException("The string must consist of at least one non-empty character");
            }

            var isNegative = false;

            for (var i = 0; i < sourceString.Length; i++)
            {
                var ch = sourceString[i];
                if (ch >= '0' && ch <= '9')
                {
                    continue;
                }

                if (ch == '-' && i == 0)
                {
                    isNegative = true;
                    continue;
                }

                throw new IncorrectFormatException("The input string must contain only digits from 0 to 9", sourceString);
            }

            BigInteger result = 0;

            var array = sourceString.ToCharArray();

            for (var i = 0; i < array.Length; i++)
            {
                var currentChar = array[array.Length - i - 1];

                if (currentChar == '-')
                {
                    continue;
                }

                var diff = ((currentChar - '0') * BigInteger.Pow(10, i));

                if (isNegative)
                {
                    result -= diff;
                }
                else
                {
                    result += diff;
                }

            }

            if (result > int.MaxValue || result < int.MinValue)
            {
                throw new OverflowException($"The number must be in the range [{int.MinValue}: {int.MaxValue}]");
            }

            return (int)result;

        }
    }



}
