using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainCollection
{
    public class Prime
    {
        internal static int[] SlectPrimes(int[] inputVals)
        {
            List<int> result = new List<int>();
            bool[] totalPrimeFlags = GetPrimeFalgs(inputVals.Max());
            for (int i = 0; i < inputVals.Length; i++)
            {
                var input = inputVals[i];
                if (totalPrimeFlags[input])
                {
                    result.Add(input);
                }
            }
            return result.ToArray();
        }

        public static bool[] GetPrimeFalgs(int v)
        {
            int prime = 2;
            var primeFlags = new PrimeFlags(v);
            while (prime < v)
            {
                primeFlags.CrossMultipleBy(prime);
                prime = primeFlags.GetNextPrime(prime);
            }
            return primeFlags.primeFlags;
        }
    }

    internal class PrimeFlags
    {
        public bool[] primeFlags;
        public PrimeFlags(int v)
        {
            primeFlags = new bool[v+1];
            InitFlags();
        }

        private void InitFlags()
        {
            for (int i = 2; i < primeFlags.Length; i++)
            {
                primeFlags[i] = true;
            }
        }

        public void CrossMultipleBy(int prime)
        {
            for (int i = prime * prime; i < primeFlags.Length; i += prime)
            {
                primeFlags[i] = false;
            }
        }

        public int GetNextPrime(int prime)
        {
            int result = prime + 1;
            while (result < primeFlags.Length && !primeFlags[result])
            {
                result++;
            }
            return result;
        }
    }
}