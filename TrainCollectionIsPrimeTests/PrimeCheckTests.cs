using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainCollection3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainCollection3.Tests
{
    [TestClass()]
    public class PrimeCheckTests
    {
        [TestMethod()]
        public void IsPrimeTest()
        {
            Assert.IsFalse(Prime.IsPrime(1));
            Assert.IsFalse(Prime.IsPrime(4));
            Assert.IsTrue(Prime.IsPrime(3));
            Assert.IsTrue(Prime.IsPrime(5));
            Assert.IsTrue(Prime.IsPrime(7));
            Assert.IsTrue(Prime.IsPrime(11));
            Assert.IsTrue(Prime.IsPrime(53));
        }
    }
}