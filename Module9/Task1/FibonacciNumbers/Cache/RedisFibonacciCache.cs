using System.Collections.Generic;
using StackExchange.Redis;

namespace FibonacciNumbers.Cache
{
    class RedisFibonacciCache : IFibonacciCache
    {
        private readonly IDatabase _db;
        public RedisFibonacciCache()
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            _db = redis.GetDatabase();

            var number1 = new FibonacciNumber { Index = 1, Value = 1, PreviousValue = null };
            var number2 = new FibonacciNumber { Index = 2, Value = 1, PreviousValue = number1 };

            AddNewValue(number1);
            AddNewValue(number2);

        } 
        
        public FibonacciNumber GetFibonacciNumber(int index)
        {
            var cachedDict = _db.HashGetAll(index.ToString()).ConvertFromRedis<FibonacciNumber>();
            return cachedDict;
        }

        public FibonacciNumber GetPreviousLargest(int index)
        {
            var values = _db.HashGetAll("values").ConvertFromRedis<List<int>>();

            for (var i = values.Count - 1; i > 0; i--)
            {
                var value = values[i];
                if (value > index)
                {
                    continue;
                }
                return _db.HashGetAll(value.ToString()).ConvertFromRedis<FibonacciNumber>();
            }

            return null;
        }

        public void AddNewValue(FibonacciNumber number)
        {
            _db.HashSet(number.Index.ToString(), number.ToHashEntries());
            var values = _db.HashGetAll("values").ConvertFromRedis<List<int>>();
            values.Add(number.Index);
            _db.HashSet("values", new List<int>().ToHashEntries());
        }
    }
}
