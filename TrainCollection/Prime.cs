using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainCollection
{
    public class Prime
    {
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

        public static int[] SlectPrimes(int[] inputVals)
        {
            bool[] primeFlags = PrimeFlags.GetPrimeFlags(inputVals.Max());
            List<int> result = new List<int>();
            foreach (var input in inputVals)
            {
                if (primeFlags[input])
                {
                   result.Add(input);
                }
            }
            return result.ToArray();
        }
    }

    public class PrimeFlags
    {
        public bool[] primeFlags;

        public PrimeFlags(int v)
        {
            this.primeFlags = new bool[v+1];
        }

        public static bool[] GetPrimeFlags(int v)
        {
            var flags = new PrimeFlags(v);
            int prime = 2; 
            flags.Init();
            while (prime < flags.primeFlags.Length)
            {
                flags.CrossMultiple(prime);
                prime = flags.GetNextPrime(prime);
            }

            return flags.primeFlags;
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

        public void CrossMultiple(int prime)
        {
            for (int i = prime*prime; i < primeFlags.Length; i += prime)
            {
                primeFlags[i] = false;
            }
        }

        public void Init()
        {
            for (int i = 2; i < primeFlags.Length; i++)
            {
                primeFlags[i] = true;
            }
        }
    }
}