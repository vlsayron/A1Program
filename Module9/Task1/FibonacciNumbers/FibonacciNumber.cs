using System.Numerics;

namespace FibonacciNumbers
{
    class FibonacciNumber
    {
        public int Index { get; set; }
        public BigInteger Value { get; set; }
        public FibonacciNumber PreviousValue { get; set; }
    }
}
