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
            int[] inputVals = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 53, 101 };
            int[] rightVals = { 2, 3, 5, 7, 11, 13, 53, 101};

            var sw = new Stopwatch();
            Console.WriteLine("Start Check whitch number is prime.");
            sw.Start();
            for (int i = 0; i < inputVals.Length; i++)
            {
                var value = inputVals[i];
                bool isPrime = IsPrimeNumber(value);
                if (rightVals.Contains(value) != isPrime)
                {
                    Console.WriteLine($"Error: Input: {value}, Result: {isPrime}");
                }
            }
            Console.WriteLine($"Prime check finish: used:{sw.ElapsedMilliseconds} ms");

            Console.WriteLine("Start Check Prime By Flags");
            sw.Reset();
            CheckPrimeByFlags();
            Console.WriteLine($"End. used: {sw.ElapsedMilliseconds} ms");


            Console.ReadKey();


            void CheckPrimeByFlags()
            {
                bool[] rightFlags = GetRightResult(inputVals, rightVals);
                bool[] primeFlags = WhichOneIsPrime(inputVals);
                if (!ResultIsRight(primeFlags, rightFlags))
                {
                        Console.WriteLine($"Error: right: {rightFlags}, result: {primeFlags}");
                }
                return;
                

                bool ResultIsRight(bool[] flags, bool[] flags2)
                {
                    return Enumerable.SequenceEqual(flags, flags2);
                    
                }
                
            }
        }

        private static bool[] GetRightResult(int[] inputVals, int[] rightVals)
        {
            bool[] result =  new bool[inputVals.Length];
            for (int i = 0; i < inputVals.Length; i++)
            {
                result[i] = rightVals.Contains(inputVals[i]);
            }
            return result;
        }

        public static bool[] WhichOneIsPrime(int[] inputVals)
        {
            if (inputVals.Length == 0) return new bool[0];
            bool[] result = new bool[inputVals.Length];
            bool[] totalPrimeFlags = new bool[inputVals.Max()+1];
            int currentPrime = 2;
            Init(totalPrimeFlags);
            while (currentPrime < totalPrimeFlags.Length)
            {
                CrossEachMultipleFor(currentPrime, totalPrimeFlags);
                currentPrime = GetNextPrime(currentPrime, totalPrimeFlags);
            }

            resultFlagsByTotal();
            return result;

            void resultFlagsByTotal()
            {

                for (int i = 0; i < inputVals.Length; i++)
                {
                    result[i] = totalPrimeFlags[inputVals[i]];
                }
            }
            void Init(bool[] primeFlags)
            {
                for (int i = 2; i < primeFlags.Length; i++)
                {
                    primeFlags[i] = true;
                }
            }
            void CrossEachMultipleFor(int prime, bool[] flags)
            {
                for (int i = prime * prime; i < flags.Length; i += prime)
                {
                    flags[i] = false;
                }
            }
        }

        public static int GetNextPrime(int currentPrime, bool[] totalPrimeFlags)
        {
            int result = currentPrime + 1;
            while (totalPrimeFlags.Length > result && !totalPrimeFlags[result])
            {
                result++;
            }
            return result;
        }

        public static bool IsPrimeNumber(int value)
        {
            bool result = true;
            if (value < 2)
            {
                return false;
            }
            for (int i = 2; i < value; i++)
            { 
                if (value % i == 0)
                {
                    return false;
                }
            }
            return result;
        }
    }

}
