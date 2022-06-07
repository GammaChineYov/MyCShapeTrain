using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainCollection.Tests
{
    [TestClass()]
    public class ProgrameTests
    {
        [TestMethod()]
        public void IsPrimeTest()
        {
            Assert.IsFalse(Programe.IsPrime(1));
            Assert.IsFalse(Programe.IsPrime(4));
            Assert.IsFalse(Programe.IsPrime(6));
            Assert.IsFalse(Programe.IsPrime(8));
            Assert.IsFalse(Programe.IsPrime(9));

            Assert.IsTrue(Programe.IsPrime(2));
            Assert.IsTrue(Programe.IsPrime(3));
            Assert.IsTrue(Programe.IsPrime(5));
            Assert.IsTrue(Programe.IsPrime(7));
        }

        [TestMethod()]
        public void GetRightFlagsTest()
        {
            int[] inputVals = { 1, 2, 3 };
            int[] rightVals = { 2, 3 };
            bool[] rightFlags = { false, true, true };

            bool[] result = Programe.GetRightFlags(inputVals, rightVals);
            Assert.IsTrue(Enumerable.SequenceEqual(result, rightFlags));

        }

        [TestMethod()]
        public void GetPrimesTest()
        {
            var max = 101;
            var result = Programe.GetPrimes(max);
            Assert.IsFalse(result[1]);
            Assert.IsFalse(result[4]);
            Assert.IsFalse(result[9]);

            Assert.IsTrue(result[2]);
            Assert.IsTrue(result[3]);
            Assert.IsTrue(result[5]);
        }
    }
}