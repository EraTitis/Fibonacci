using System.Collections.Generic;

namespace Fibonacci.Api
{
    public interface INumberFrequencyService
    {
        /// <summary>
        /// A collection of pairs of numbers and their frequency
        /// </summary>
        Dictionary<double, int> Numbers { get; }

        /// <summary>
        /// Adds the given number to the collection if not exists, and increments its frequency
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Returns the frequency of the given number</returns>
        int IncrementFrequency(double number);
    }
}