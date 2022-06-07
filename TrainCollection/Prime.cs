using System;

namespace TrainCollection
{
    public class Prime
    {
        public Prime()
        {
        }

        internal bool[] GetPrimes(int v)
        {

            bool[] primeFlags = new bool[v + 1];
            Init(primeFlags);
            int currentPrime = 2;
            while (currentPrime < primeFlags.Length)
            {
                CrossMultiplyBy(currentPrime, primeFlags);

                currentPrime = GetNextPrime(currentPrime, primeFlags);
            }
            return primeFlags;

            void Init(bool[] flags)
            {
                for (int i = 2; i < flags.Length; i++)
                {
                    flags[i] = true;
                }
            }
        }

        public int GetNextPrime(int prime, bool[] primeFlags)
        {
            if (prime < 2) return 2;
            int result = prime + 1;
            while (result < primeFlags.Length && !primeFlags[result])
            {
                result++;
            }
            return result;
        }

        public void CrossMultiplyBy(int currentPrime, bool[] primeFlags)
        {
            for (int i = currentPrime * currentPrime; i < primeFlags.Length; i += currentPrime)
            {
                primeFlags[i] = false;
            }
        }
    }
}