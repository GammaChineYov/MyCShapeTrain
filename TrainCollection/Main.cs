using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TrainCollection
{
	public class Programe
    {
        static int[] inputVals = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 101 };
        static int[] rightVals = { 2, 3, 5, 7, 11, 101 };

        public static void Main()
        {
            var sw = new Stopwatch();
            Console.WriteLine("Start check which is prime");
            sw.Start();
            CheckIsPrime();
            Console.WriteLine($"End. used:{sw.ElapsedMilliseconds} ms");
            Console.WriteLine("Start select primes");
            sw.Reset();
            SelectPrimes();
            Console.WriteLine($"End. used:{sw.ElapsedMilliseconds} ms");

            Console.ReadKey();
        }

        private static void SelectPrimes()
        {
            int[] primes = Prime.SlectPrimes(inputVals);
            if (!Enumerable.SequenceEqual(rightVals, primes))
            {
                Console.WriteLine($"Error: right:{rightVals.Length}, result:{primes}");

            }
        }

        public static void CheckIsPrime()
        {
            for (int i = 0; i < inputVals.Length; i++)
            {
                var input = inputVals[i];
                bool isPrime = IsPrime(input);
                if (rightVals.Contains(input) != isPrime)
                {
                    Console.WriteLine($"Error: Input:{input} result:{isPrime}");
                }
            }
        }

        public static bool IsPrime(int input)
        {
            if (input < 2) return false;
            for (int i = 2; i < input; i++)
            {
                if (input % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }

}
