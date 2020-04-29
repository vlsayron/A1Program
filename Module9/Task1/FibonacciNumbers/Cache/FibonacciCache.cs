using System.Collections.Generic;

namespace FibonacciNumbers.Cache
{
    class FibonacciCache : IFibonacciCache
    {
        private readonly System.Web.Caching.Cache _cache;
        public FibonacciCache()
        {
            _cache = new System.Web.Caching.Cache();
            _cache.Insert("values", new List<int>());

            var number1 = new FibonacciNumber { Index = 1, Value = 1, PreviousValue = null };
            var number2 = new FibonacciNumber { Index = 2, Value = 1, PreviousValue = number1 };

            AddNewValue(number1);
            AddNewValue(number2);
        }

        public FibonacciNumber GetFibonacciNumber(int index)
        {
            var cachedDict = (FibonacciNumber)_cache[index.ToString()];
            return cachedDict;
        }

        public FibonacciNumber GetPreviousLargest(int index)
        {
            var values = (List<int>)_cache["values"];

            for (var i = values.Count-1; i > 0 ; i--)
            {
                var value = values[i];
                if (value > index)
                {
                    continue;
                }

                return (FibonacciNumber)_cache[value.ToString()];
            }

            return null;
        }

        public void AddNewValue(FibonacciNumber number)
        {
            _cache.Insert(number.Index.ToString(), number);
            var values = (List<int>)_cache["values"];
            values.Add(number.Index);
        }
    }
}
