namespace FibonacciNumbers.Cache
{
    interface IFibonacciCache
    {
        FibonacciNumber GetFibonacciNumber(int index);
        FibonacciNumber GetPreviousLargest(int index);
        void AddNewValue(FibonacciNumber number);
    }
}
