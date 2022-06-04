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
        public void CheckIsPrimeTest()
        {
            Assert.IsFalse(Programe.CheckIsPrime(1));
            Assert.IsTrue(Programe.CheckIsPrime(2));
            Assert.IsTrue(Programe.CheckIsPrime(3));
            Assert.IsFalse(Programe.CheckIsPrime(4));
            Assert.IsTrue(Programe.CheckIsPrime(5));
            Assert.IsFalse(Programe.CheckIsPrime(6));
            Assert.IsTrue(Programe.CheckIsPrime(7));
        }

        [TestMethod()]
        public void GetPrimeFlagsForTest()
        {
            bool[] result = Programe.GetPrimeFlagsFor(13);
            Assert.AreEqual(result[0], false);
            Assert.AreEqual(result[1], false);
            Assert.AreEqual(result[2], true);
            Assert.AreEqual(result[3], true);
            Assert.AreEqual(result[4], false);
            Assert.AreEqual(result[5], true);
            Assert.AreEqual(result[6], false);
            Assert.AreEqual(result[7], true);
            Assert.AreEqual(result[8], false);
        }
    }
}