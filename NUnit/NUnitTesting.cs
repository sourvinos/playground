using NUnit.Framework;

namespace NUnitTesting
{
    public class UnitTestOne
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

    [TestFixture]
    public class UnitTestOneTesting
    {
        UnitTestOne s;

        [SetUp]
        public void SetUp()
        {
            s = new UnitTestOne();
        }

        [TestCase(+1, +1)]
        [TestCase(-1, +1)]
        [TestCase(-1, -1)]
        [TestCase(+1, -1)]
        [Test]
        public void Add_CheckResult_CorrectSum(int a, int b)
        {
            int result = s.Add(a, b);
            int expected = a + b;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void IsTestingFun_CheckIfTrue_True()
        {
            bool result = s.IsTestingFun();

            Assert.IsTrue(result);
        }
    }
}
