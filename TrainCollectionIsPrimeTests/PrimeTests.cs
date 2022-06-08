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
        public void GetPrimeFalgsTest()
        {
            Assert.IsFalse(Prime.GetPrimeFalgs(11)[1]);
            Assert.IsFalse(Prime.GetPrimeFalgs(11)[4]);
            Assert.IsFalse(Prime.GetPrimeFalgs(11)[6]);

            Assert.IsTrue(Prime.GetPrimeFalgs(11)[2]);
            Assert.IsTrue(Prime.GetPrimeFalgs(11)[3]);
            Assert.IsTrue(Prime.GetPrimeFalgs(11)[5]);
            Assert.IsTrue(Prime.GetPrimeFalgs(11)[7]);
        }
    }
}