using System;
using System.Linq;
using System.Timers;
using Fibonacci.Api;

namespace Fibonacci.ConsoleApp
{
    class Program
    {
        private static NumberFrequencyService _numberFrequencyService;

        static void Main(string[] args)
        {
            const int MILISECONDS = 1000;
            _numberFrequencyService = new NumberFrequencyService();
            var fibonacciService = new FibonacciService();

            Console.WriteLine("Please enter the amount of time in seconds between emitting numbers and their frequency");

            string interval;
            long intervalSeconds = 0;
            while (!string.IsNullOrWhiteSpace(interval = Console.ReadLine()) &&
                    (!long.TryParse(interval, System.Globalization.NumberStyles.Integer, null, out intervalSeconds) || intervalSeconds <= 0))
            {
                Console.WriteLine("Error: The amount of time must be a positive integer and greater than 0.");
            }

            var timer = new Timer(intervalSeconds * MILISECONDS)
            {
                AutoReset = true,
                Enabled = true
            };
            timer.Elapsed += OnTimerElapsed;
            timer.Start();

            Console.WriteLine("Please enter the first number");
            string input;

            while ((input = Console.ReadLine().ToLowerInvariant()) != "quit")
            {
                switch (input)
                {
                    case "halt":
                        Console.WriteLine("timer halted");
                        timer.Stop();
                        continue;
                    case "resume":
                        Console.WriteLine("timer resumed");
                        timer.Start();
                        continue;
                }

                double number = 0;

                if (!double.TryParse(input, System.Globalization.NumberStyles.Integer, null, out number))
                {
                    Console.WriteLine("Error: The number must be an integer.");
                    continue;
                }
                else
                {
                    _numberFrequencyService.IncrementFrequency(number);

                    if (fibonacciService.IsFibonacci(number))
                    {
                        Console.WriteLine("FIB");
                    }

                    Console.WriteLine("Please enter the next number");
                }
            }

            // show all numbers and their frequency before exiting
            DisplayNumbersFrequency();
        }

        private static void OnTimerElapsed(Object source, ElapsedEventArgs e)
        {
            DisplayNumbersFrequency();
        }

        private static void DisplayNumbersFrequency()
        {
            var numFrequency = string.Join(", ", _numberFrequencyService.Numbers.Select(x => $"{x.Key}:{x.Value}"));
            Console.WriteLine(numFrequency);
        }
    }
}
