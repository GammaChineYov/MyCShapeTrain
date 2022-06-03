using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TrainCollection2
{
    class _Program
    {
        public static void _Main(string[] args)
        {
            int[] testVals = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 53 };
            int[] rightPrimes = { 2, 3, 5, 7, 11, 53};
            for (int i = 0; i < testVals.Length; i++)
            {
                var inputVal = testVals[i];
                var realIsPrime = rightPrimes.Contains(inputVal);
                var isPrime = CheckPrimeNum(inputVal);
                if ((realIsPrime && isPrime != true) || (!realIsPrime && isPrime != false))
                {
                    Console.WriteLine($"错误: 输入{inputVal},期望: {realIsPrime}, 输出: {isPrime}");
                }
                else if (realIsPrime && isPrime)
                {
                    Console.WriteLine($"正确, 输入: {inputVal}, 输出:{isPrime}");
                }
            }

            Console.WriteLine("Start Get Primes Test ");

            int[] actualPrimes = PrimeNum.GetPrimes(testVals);
            if (Enumerable.SequenceEqual(actualPrimes,rightPrimes))
            {
                Console.WriteLine("right Result");
            }
            else
            {
                Console.WriteLine("Bad Result");
                Console.WriteLine($"Right Res: {getArrayString(rightPrimes)}");
                Console.WriteLine($"Actual Res: {getArrayString(actualPrimes)}");
            }

            Console.WriteLine("按任意字符结束");
            Console.ReadKey();
        }

        public static string getArrayString<T>(T[] values)
        {
            string[] strVals = new string[values.Length];
            for (int i = 0; i < strVals.Length; i++) strVals[i] = values[i].ToString();
            return string.Join(" ", strVals);
        }

        private static bool CheckPrimeNum(int inputVal)
        {
            if (inputVal < 2)
            {
                return false;
            }
            var sqrt = Math.Sqrt(inputVal);
            for (int i = 2; i <= sqrt; i++)
            {
                if (inputVal % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
    public class PrimeNum
    {
        public static int[] GetPrimes(int[] inputVals)
        {
            int maxInputVal = Enumerable.Max(inputVals);
            int[] totalPrimes = GetPrimes(maxInputVal);
            List<int> outPrimes = new List<int>();
            for (int i = 0; i < inputVals.Length; i++)
            {
                if (totalPrimes.Contains(inputVals[i])) 
                    outPrimes.Add(inputVals[i]);
            }
            return outPrimes.ToArray();
        }

        public static int[] GetPrimes(int maxValue)
        {
            bool[] isPrimes = new bool[maxValue + 1];
            PrimesFlagInit(isPrimes);
            int prime = 2;
            int sqrt = (int)Math.Sqrt(maxValue);
            while (prime <= sqrt)
            {
                // delete prime's multiple value;
                crossOff(isPrimes, prime);

                prime = getNextPrime(isPrimes, prime);
            }
            return PrimeFlagsToPrimes(isPrimes);
        }

        private static int[] PrimeFlagsToPrimes(bool[] isPrimes)
        {
            List<int> primes = new List<int>();
            for (int i = 2; i < isPrimes.Length; i++)
            {
                if (isPrimes[i]) primes.Add(i);
            }
            return primes.ToArray();
        }


        private static int getNextPrime(bool[] isPrimes, int prime)
        {
            prime++;
            while (prime < isPrimes.Length && !isPrimes[prime])
            {
                prime++;
            }
            return prime;
        }

        private static void crossOff(bool[] isPrimes, int prime)
        {
            for (int i = prime * prime; i < isPrimes.Length; i += prime)
            {
                isPrimes[i] = false;
            }
        }

        // Set true except 0,1
        private static void PrimesFlagInit(bool[] isPrimes)
        {
            for (int i = 2; i < isPrimes.Length; i++)
            {
                isPrimes[i] = true;
            }
        }
    }
}