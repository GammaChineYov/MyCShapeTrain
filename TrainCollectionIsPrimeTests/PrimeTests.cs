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
    public class PrimeTests
    {
        [TestMethod()]
        public void IsPrimeTest()
        {
            Assert.IsFalse(Prime.IsPrime(1));
            Assert.IsFalse(Prime.IsPrime(8));
            Assert.IsFalse(Prime.IsPrime(4));
            Assert.IsFalse(Prime.IsPrime(6));

            Assert.IsTrue(Prime.IsPrime(2));
            Assert.IsTrue(Prime.IsPrime(3));
            Assert.IsTrue(Prime.IsPrime(5));
            Assert.IsTrue(Prime.IsPrime(7));
        }

        [TestMethod()]
        public void SlectPrimesTest()
        {
            int[] inputVals = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int[] rightVasl = { 2, 3, 5, 7, 11 };

            var result = Prime.SlectPrimes(inputVals);
            Assert.IsTrue(Enumerable.SequenceEqual(rightVasl, inputVals));
        }
    }
}