using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainCollection
{
    class PrimeNumberCheck
    {
        static void Run(string[] args)
        {
            var nums = new int[] { 1, 2, 3, 4, 5, 7, 10, 51, 87, 100 };
            var rightAnswer = new int[] { 2, 3, 5, 7};
            List<int> resCollection = new List<int>();
            foreach (var num in nums)
            {
                bool res = ALTSprimeNumberCheck(num);
                //bool res = primeNumberCheck(num);
                bool isPrimeAnswer = rightAnswer.Contains(num);
                if ((isPrimeAnswer && res == false) || (!isPrimeAnswer && res == true))
                {
                    Console.WriteLine($"输入{num}, 输出{res}, 错误");
                }
                else if (isPrimeAnswer)
                {
                    resCollection.Add(num);
                    Console.WriteLine($"{num} is Prime ");
                }
            }
            Console.ReadLine();
        }
        // 埃拉托斯特
        public static bool ALTSprimeNumberCheck(int num)
        {
            if (num < 2) return false;
            bool[] flags = new bool[num + 1];
            for (int i = 0; i< flags.Length; i++) flags[i] = true;
            int prime = 2;
            while (prime <= Math.Sqrt(num))
            {
                /*删除剩余的Prime的倍数*/
                corssOff(flags, prime);
                /* 找到下一个标识为true的数*/
                prime = nextPrime(flags, prime);
                if (!flags[num]) return false;
            }
            return flags[num];
        }

        private static int nextPrime(bool[] flags, int prime)
        {
            int next = prime + 1;
            while(next < flags.Length && flags[next] == false)
            {
                next++;
            }
            return next;
        }

        private static void corssOff(bool[] flags, int prime)
        {
            for (int i = prime * prime; i < flags.Length; i+=prime)
            {
                flags[i] = false;
            }
        }

        private static bool primeNumberCheck(int num)
        {
            if (num < 2)
            {
                return false;
            }
            int sqrt = (int)Math.Sqrt(num);
            for (int i = 2; i <= sqrt; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        
    }
}
