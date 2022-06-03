using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainCollection3
{
    class Programe3
    {
        public static void Main3()
        {
            var inputVals = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 53 };
            var rightVals = new int[] { 2, 3, 5, 7, 11, 53 };
            for (int i = 0;  i < inputVals.Length; i++)
            {
                bool isPrime = Prime.IsPrime(inputVals[i]);
                if (rightVals.Contains(inputVals[i]) != isPrime)
                {
                    Console.WriteLine($"result error: intputVal: {inputVals[i]} output: {isPrime}");

                }
            }
            Console.WriteLine("Start ALTSTN Prime filter");
            bool[] IsPrimeFlags = Prime.AMethodGeneratePrimes(inputVals.Max());
            foreach (int i in inputVals)
            {
                if (rightVals.Contains(i)!=IsPrimeFlags[i])
                {
                    Console.WriteLine($"Result Error: input: {i}, Output: {IsPrimeFlags[i]}");
                }
            }
            Console.WriteLine("按任意键结束");
            Console.ReadKey();
        }
    }

    public class Prime
    {
        public static bool IsPrime(int v)
        {
            if (v < 2)
            {
                return false;
            }
            int sqrt = (int)Math.Sqrt(v);
            for (int i = 2; i <= sqrt; i++)
            {
                if (v % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool[] AMethodGeneratePrimes(int v)
        {
            bool[] primeFlags = new bool[v+1];
            PrimeFlagsInit(primeFlags);
            int prime = 2;
            while (prime < primeFlags.Length)
            {
                crossPrimeFlag(primeFlags, prime);
                prime = getNextPrime(primeFlags, prime);
            }
            return primeFlags;
        }

        private static int getNextPrime(bool[] primeFlags, int prime)
        {
            prime++;
            while (prime< primeFlags.Length && !primeFlags[prime])
            {
                prime++;
            }
            return prime;
        }

        private static void crossPrimeFlag(bool[] primeFlags, int prime)
        {

            for (int i=prime*prime; i < primeFlags.Length; i+= prime)
            {
                primeFlags[i] = false;
            }
        }

        public static void PrimeFlagsInit(bool[] primeFlags)
        {
            if (primeFlags.Length < 2)
            {
                return;
            }
            for (int i = 2; i < primeFlags.Length; i++)
            {
                primeFlags[i] = true;
            }
        }
    }
}
