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
        public void CrossMultiplyByTest()
        {
            var prime = new Prime();
            var flags = new bool[] { false, false, true, true, true };

            prime.CrossMultiplyBy(2, flags);
            Assert.IsFalse(flags[4]);

        }

        [TestMethod()]
        public void GetNextPrimeTest()
        {
            var prime = new Prime();
            var flags = new bool[] { false, false, true, true , false, true};
            var result = prime.GetNextPrime(1, flags);
            Assert.AreEqual(result, 2);
            result = prime.GetNextPrime(3, flags);
            Assert.AreEqual(result, 5);
        }
    }
}