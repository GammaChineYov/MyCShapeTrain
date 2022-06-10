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
    public class PrimeFlagsTests
    {
        [TestMethod()]
        public void GetPrimeFlagsTest()
        {
            var flags = PrimeFlags.GetPrimeFlags(10);
            Assert.IsTrue(flags[2]);
            Assert.IsTrue(flags[3]);
            Assert.IsFalse(flags[4]);
            Assert.IsFalse(flags[6]);
        }

        [TestMethod()]
        public void GetNextPrimeTest()
        {
            var flags = new PrimeFlags(10);
            flags.Init();
            flags.CrossMultiple(2);
            Assert.IsFalse(flags.primeFlags[4]);
            var next = flags.GetNextPrime(2);
            Assert.AreEqual(next, 3);
        }
    }
}