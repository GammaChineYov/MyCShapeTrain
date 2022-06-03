using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainCollection2;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] rightVals = new int[] { 2, 3, 5, 7 };
            int[] primes = PrimeNum.GetPrimes(10);
            Assert.AreEqual(primes.Length, rightVals.Length);
            for (int i = 0; i < primes.Length; i++)
            {
                Assert.AreEqual(primes[i], rightVals[i]);
            }

        }
    }
}
