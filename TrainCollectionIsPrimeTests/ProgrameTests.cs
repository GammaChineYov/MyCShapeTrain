using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainCollection4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainCollection4.Tests
{
    [TestClass()]
    public class ProgrameTests
    {
        [TestMethod()]
        public void IsPrimeNumberTest()
        {
            Assert.IsFalse(Programe.IsPrimeNumber(1));
            Assert.IsFalse(Programe.IsPrimeNumber(4));
            Assert.IsFalse(Programe.IsPrimeNumber(6));
            Assert.IsFalse(Programe.IsPrimeNumber(8));
            Assert.IsFalse(Programe.IsPrimeNumber(9));

            Assert.IsTrue(Programe.IsPrimeNumber(2));
            Assert.IsTrue(Programe.IsPrimeNumber(3));
            Assert.IsTrue(Programe.IsPrimeNumber(5));
            Assert.IsTrue(Programe.IsPrimeNumber(7));
            Assert.IsTrue(Programe.IsPrimeNumber(11));

        }

        [TestMethod()]
        public void WhichOneIsPrimeTest()
        {
            int[] inputVals = { 1, 2, 3, 4 };
            bool[] rightFlags = { false, true, true, false };

            bool[] result = Programe.WhichOneIsPrime(inputVals);
            Assert.IsTrue(Enumerable.SequenceEqual(rightFlags, result));
        }

        [TestMethod()]
        public void GetNextPrimeTest()
        {
            int[] inputVals = { 1, 2, 3, 4, 5, 6 , 7};
            bool[] rightFlags = { false, false, true, true, false, true, false , true};
            Assert.AreEqual(Programe.GetNextPrime(1, rightFlags), 2);
            Assert.AreEqual(Programe.GetNextPrime(4, rightFlags), 5);
            Assert.AreEqual(Programe.GetNextPrime(5, rightFlags), 7);
        }
    }
}