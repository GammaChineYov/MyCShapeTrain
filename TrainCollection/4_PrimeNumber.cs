using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainCollection4
{
    class Programe
    {
        public static void Main()
        {
            Console.WriteLine("simple Prime check");
            int[] inputVals = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 53 };
            int[] rightVals = new int[] { 2, 3, 5, 7, 11, 53 };
            for (int i = 0; i < inputVals.Length; i++)
            {
                var val = inputVals[i];
                bool isPrime = Prime.IsPrime(val);
                if (isPrime != rightVals.Contains(val))
                {
                    Console.WriteLine($"error: Input: {val} output: {isPrime}");
                }
            }
            Console.WriteLine("AL Pradicate Method Gen Primes");
            bool[] primeFlags = Prime.GeneratePrimeFlags(inputVals.Max());
            for (int i = 0; i < inputVals.Length; i++)
            {
                if (rightVals.Contains(inputVals[i]) != primeFlags[inputVals[i]])
                {
                    Console.WriteLine($"Error: Input: {inputVals[i]} Output: {primeFlags[inputVals[i]]}");
                }
            }
            Console.WriteLine("按任意键结束");
            Console.ReadKey();
        }
    }

    public class Prime
    {
        public static bool IsPrime(int val)
        {
            if (val < 2)
            {
                return false;
            }
            for (int i = 2; i < val; i++)
            {
                if (val % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool[] GeneratePrimeFlags(int v)
        {
            bool[] primeFlags = new bool[v+1];
            if (v < 2) return primeFlags;
            primeFlagsInit(primeFlags);
            int prime = 2;
            while (prime < primeFlags.Length)
            {
                // set false of prime's multiple 
                CorssFlagOfPrimeMultiples(primeFlags, prime);

                prime = GetNextPrime(primeFlags, prime);
            }

            return primeFlags;
        }

        public static int GetNextPrime(bool[] primeFlags, int prime)
        {
            prime++;
            while (primeFlags.Length > prime && !primeFlags[prime])
            {
                prime++;
            }
            return prime;
        }

        public static void CorssFlagOfPrimeMultiples(bool[] primeFlags, int prime)
        {
            for (int i = prime * prime; i < primeFlags.Length; i += prime)
            {
                primeFlags[i] = false;
            }
        }

        private static void primeFlagsInit(bool[] primeFlags)
        {
            for (int i = 2; i < primeFlags.Length; i++)
            {
                primeFlags[i] = true;
            }
        }
    }
}
