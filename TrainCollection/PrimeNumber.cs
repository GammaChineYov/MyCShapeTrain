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
            Console.WriteLine("Start check is prime.");
            CheckIsPrime();
            Console.WriteLine($"End. used:{sw.ElapsedMilliseconds} ms");

            Console.WriteLine("Start check prime by flags");
            CheckPrimeByFlags();
            Console.WriteLine($"End. used:{sw.ElapsedMilliseconds} ms");

            Console.ReadKey();

        }

        private static void CheckPrimeByFlags()
        {
            bool[] rightPrimeFlags = GetRightFlags(inputVals, rightVals);
            bool[] primeFlags = IsPrimes(inputVals);
            if (!Enumerable.SequenceEqual(rightPrimeFlags, primeFlags))
            {
                Console.WriteLine($"Error. right: {rightPrimeFlags} result: {primeFlags}");
            }
        }

        private static bool[] IsPrimes(int[] inputVals)
        {
            bool[] result = new bool[inputVals.Length];
            bool[] totalPrimeFlags = GetPrimes(inputVals.Max());
            for (int i = 0; i < inputVals.Length; i++)
            {
                var val = inputVals[i];
                result[i] = totalPrimeFlags[val];
            }
            return result;
        }

        public static bool[] GetPrimes(int v)
        {
            var prime = new Prime();
            return prime.GetPrimes(v);
        }

        public static bool[] GetRightFlags(int[] inputVals, int[] rightVals)
        {
            bool[] result = new bool[inputVals.Length];
            for (int i = 0; i < inputVals.Length; i++)
            {
                if (rightVals.Contains(inputVals[i]))
                {
                    result[i] = true;
                }
            }
            return result;
        }

        private static void CheckIsPrime()
        {
            for (int i = 0; i < inputVals.Length; i++)
            {
                var input = inputVals[i];
                bool isPrime = IsPrime(input);
                if (rightVals.Contains(input) != isPrime)
                {
                    Console.WriteLine($"Error: Input:{input} result: {isPrime}");
                }
            }
        }


        public static bool IsPrime(int input)
        {
            bool result = true;
            if (input < 2)
            {
                return false;
            }
            for (int i = 2; i < input; i++)
            {
                if (input % i == 0)
                {
                    return false;
                }
            }
            return result;
        }
    }

}
