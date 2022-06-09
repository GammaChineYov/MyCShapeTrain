using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainCollection
{
    public class Prime
    {
        public  static int[] SlectPrimes(int[] inputVals)
        {
            List<int> result = new List<int>();
            int[] primes = GetPrimes(inputVals.Max());
            for (int i = 0; i < inputVals.Length; i++)
            {
                if (primes.Contains(inputVals[i]))
                {
                    result.Add(inputVals[i]);
                }
            }
            return result.ToArray();
        }

        private static int[] GetPrimes(int v)
        {
            List<int> result = new List<int>();
            bool[] primesFlags = GetPrimeFlags(v);
            
            for (int i = 2; i < v + 1; i++)
            {
                if (primesFlags[i])
                {
                    result.Add(i);
                }
            }
            return result.ToArray();
        }

        private static bool[] GetPrimeFlags(int v)
        {
            bool[] primeFlags = new bool[v+1];
            int prime = 2;
            Init(primeFlags);
            while (prime < primeFlags.Length)
            {
                CrossMultipleFor(prime, primeFlags);

                prime = GetNextPrime(prime, primeFlags);
            }
            return primeFlags;
        }

        private static void Init(bool[] primeFlags)
        {
            for (int i = 2; i < primeFlags.Length; i++)
            {
                primeFlags[i] = true;
            }
        }

        private static int GetNextPrime(int prime, bool[] primeFlags)
        {
            var result = prime + 1;
            while (result < primeFlags.Length && !primeFlags[result])
            {
                result++;
            }
            return result;
        }

        private static void CrossMultipleFor(int prime, bool[] primeFlags)
        {
            if (prime == 0) return;
            for (int i = prime * prime; i < primeFlags.Length; i += prime)
            {
                primeFlags[i] = false;
            }
        }
    }
}