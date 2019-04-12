using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTesting
{
    public class UnitTestTwo
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public bool IsTestingFun()
        {
            return true;
        }
    }

    [TestClass]
    public class UnitTestTwoTesting
    {
        [TestMethod]
        public void Add_CheckResult_Seven()
        {
            UnitTestTwo s = new UnitTestTwo();

            int result = s.Add(4, 3);

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void IsTestingFun_CheckIfTrue_True()
        {
            UnitTestTwo s = new UnitTestTwo();

            bool result = s.IsTestingFun();

            Assert.IsTrue(result);
        }

    }
}
