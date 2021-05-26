namespace Fibonacci.Api
{
    public interface IFibonacciService
    {
        /// <summary>
        /// Checks if a number is a Fibonacci number
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Returns True if the number is a Fibonacci, otherwise False</returns>
        bool IsFibonacci(double number);
    }
}