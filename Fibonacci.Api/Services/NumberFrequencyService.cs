using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Fibonacci.Api
{
    public class NumberFrequencyService : INumberFrequencyService
    {
        private readonly ConcurrentDictionary<double, int> _numbers;

        public NumberFrequencyService()
        {
            _numbers = new ConcurrentDictionary<double, int>();
        }

        public Dictionary<double, int> Numbers => _numbers.ToArray()
                                                                .OrderByDescending(x => x.Value)
                                                                .ToDictionary(x => x.Key, x => x.Value);

        public int IncrementFrequency(double number)
        {
            _numbers.AddOrUpdate(number, 1, (number, existingFrequency) => existingFrequency + 1);

            return _numbers[number];
        }
    }
}