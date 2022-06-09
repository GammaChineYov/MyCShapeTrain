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

            Assert.IsTrue(Programe.IsPrime(2));
            Assert.IsTrue(Programe.IsPrime(3));
            Assert.IsTrue(Programe.IsPrime(5));
        }
    }
}