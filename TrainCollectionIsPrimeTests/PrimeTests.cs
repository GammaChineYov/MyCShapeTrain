using TrainCollection4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainCollection3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainCollection4.Tests
{
    [TestClass()]
    public class PrimeTests
    {
        static bool[] inputFlags = new bool[] { false, false, true, true, true, true, true };
        [TestMethod()]
        public void IsPrimeTest()
        {
            Assert.IsFalse(Prime.IsPrime(1));
            Assert.IsTrue(Prime.IsPrime(2));
            Assert.IsTrue(Prime.IsPrime(3));
            Assert.IsFalse(Prime.IsPrime(4));
            Assert.IsTrue(Prime.IsPrime(5));
            Assert.IsFalse(Prime.IsPrime(6));
            Assert.IsTrue(Prime.IsPrime(7));
            Assert.IsFalse(Prime.IsPrime(8));
        }

        [TestMethod()]
        public void GeneratePrimeFlagsTest()
        {
            Assert.IsFalse(Prime.GeneratePrimeFlags(10)[1]);
            Assert.IsTrue(Prime.GeneratePrimeFlags(10)[2]);
            Assert.IsTrue(Prime.GeneratePrimeFlags(10)[3]);
            Assert.IsFalse(Prime.GeneratePrimeFlags(10)[4]);
            Assert.IsTrue(Prime.GeneratePrimeFlags(10)[5]);
            Assert.IsFalse(Prime.GeneratePrimeFlags(10)[6]);
            Assert.IsTrue(Prime.GeneratePrimeFlags(10)[7]);
            Assert.IsFalse(Prime.GeneratePrimeFlags(10)[8]);

        }

        [TestMethod()]
        public void CorssFlagOfPrimeMultiplesTest()
        {
            int prime = 2;
            Prime.CorssFlagOfPrimeMultiples(inputFlags, prime);
            Assert.IsTrue(inputFlags[2]);
            Assert.IsTrue(inputFlags[3]);
            Assert.IsFalse(inputFlags[4]);
            Assert.IsTrue(inputFlags[5]);
            Assert.IsFalse(inputFlags[6]);
        }

        [TestMethod()]
        public void GetNextPrimeTest()
        {
            int prime = 2;
            Assert.AreEqual(Prime.GetNextPrime(inputFlags, prime), 3);
            prime = 3;
            inputFlags[4] = false;
            Assert.AreEqual(Prime.GetNextPrime(inputFlags, prime), 5);
            

        }
    }
}

namespace TrainCollection3.Tests
{
    [TestClass()]
    public class PrimeTests
    {
        [TestMethod()]
        public void AMethodGeneratePrimesTest()
        {
            Assert.AreEqual(Prime.AMethodGeneratePrimes(5)[1], false);
            Assert.AreEqual(Prime.AMethodGeneratePrimes(5)[2], true);
            Assert.AreEqual(Prime.AMethodGeneratePrimes(5)[3], true);
            Assert.AreEqual(Prime.AMethodGeneratePrimes(5)[4], false);
            Assert.AreEqual(Prime.AMethodGeneratePrimes(5)[5], true);
            Assert.AreEqual(Prime.AMethodGeneratePrimes(11)[6], false);
            Assert.AreEqual(Prime.AMethodGeneratePrimes(11)[10], false);
        }

        [TestMethod()]
        public void PrimeFlagsInitTest()
        {
            bool[] flags = new bool[2];
            Prime.PrimeFlagsInit(flags);
            Assert.AreEqual(flags[0], false);
            Assert.AreEqual(flags[1], false);

            bool[] flags2 = new bool[4];
            Prime.PrimeFlagsInit(flags2);
            Assert.AreEqual(flags2[0], false);
            Assert.AreEqual(flags2[1], false);
            Assert.AreEqual(flags2[2], true);
            Assert.AreEqual(flags2[3], true);
        }
    }
}