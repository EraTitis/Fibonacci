using System;

namespace Fibonacci.Api
{
    public class FibonacciService : IFibonacciService
    {
        public bool IsFibonacci(double number)
        {
            //sourced from https://stackoverflow.com/questions/2432669/test-if-a-number-is-fibonacci

            double root5 = Math.Sqrt(5);
            double phi = (1 + root5) / 2;

            long idx = (long)Math.Floor(Math.Log(number * root5) / Math.Log(phi) + 0.5);
            if (idx > 1000) return false;

            double u = (double)Math.Floor(Math.Pow(phi, idx) / root5 + 0.5);
            return (u == number);
        }
    }
}