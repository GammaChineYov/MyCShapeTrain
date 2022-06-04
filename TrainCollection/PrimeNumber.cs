using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TrainCollection4
{
    public class Programe
    {
        public static void Main()
        {
            int[] inputVals = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int[] rightVals = { 2, 3, 5, 7, 11};
            var sw = new Stopwatch();
            Console.WriteLine("Check is Prime");
            sw.Start();
            for (int i = 0; i < inputVals.Length; i++)
            {
                int input = inputVals[i];
                bool isPrime = CheckIsPrime(input);
                if (rightVals.Contains(input) != isPrime)
                {
                    Console.WriteLine($"Error Input: {input}, result: {isPrime}");
                }
            }
            Console.WriteLine($"Check Complete, cd:{sw.ElapsedMilliseconds}");

            Console.WriteLine("ALTS Prime method");
            int maxVal = inputVals.Max();
            bool[] primesFlags = GetPrimeFlagsFor(maxVal);
            for (int i = 0; i < primesFlags.Length; i++)
            {
                if (rightVals.Contains(i) != primesFlags[i])
                {
                    Console.WriteLine($"Error: Input:{i}, Output{primesFlags[i]}");
                }
            }
            Console.WriteLine($"ALTS Finish, cd: {sw.ElapsedMilliseconds}");

            Console.ReadKey();


        }

        public static bool[] GetPrimeFlagsFor(int maxVals)
        {
            bool[] result = new bool[maxVals];
            for (int i = 2; i < result.Length; i++) result[i] = true;
            var prime = new Prime();
            while (prime.CurrentPrime < result.Length)
            {
                Prime.SetFalseOfMultiple(result, prime.CurrentPrime);

                prime.CurrentPrime = Prime.GetNextPrime(result, prime.CurrentPrime);
            }
            return result;
        }


        public static bool CheckIsPrime(int input)
        {
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
            return true;
        }
    }

    internal class Prime
    {
        public Prime()
        {
        }

        public int CurrentPrime { get; internal set; } = 2;

        public static void SetFalseOfMultiple(bool[] primeFlags, int prime)
        {
            for (int i = prime * prime; i < primeFlags.Length; i += prime)
            {
                primeFlags[i] = false;
            }
        }

        public static int GetNextPrime(bool[] primeFlags, int prime)
        {
            prime++;
            while (prime < primeFlags.Length && !primeFlags[prime])
            {
                prime++;
            }

            return prime;
        }
    }
}
