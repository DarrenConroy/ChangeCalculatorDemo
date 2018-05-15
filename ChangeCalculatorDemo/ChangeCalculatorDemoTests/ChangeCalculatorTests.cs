using ChangeCalculatorDemo;
using NUnit.Framework;

namespace ChangeCalculatorDemoTests
{
    [TestFixture]
    public class ChangeCalculatorTests
    {
        [Test]
        public void GetChange_NotNull()
        {
            var change = ChangeCalculator.GetChange(0, 0);
            Assert.IsNotNull(change);
        }

        [TestCase(2, 1, 1)]
        [TestCase(2000, 550, 1450)]
        public void GetChange_Various_CorrectChange(int receivedMoney, int productPrice, int expected)
        {
            var change = ChangeCalculator.GetChange(receivedMoney, productPrice);
            Assert.AreEqual(expected, change);
        }

        [TestCase(100000, 1)]
        [TestCase(9000, 2)]
        [TestCase(5000, 1)]
        [TestCase(4000, 1)]
        [TestCase(2000, 1)]
        [TestCase(1000, 1)]
        [TestCase(1050, 2)]
        [TestCase(9876, 9)]
        [TestCase(1, 1)]
        [TestCase(0, 0)]
        public void DisplayChange_Count(int change, int lineCount)
        {
            ChangeCalculator cc = new ChangeCalculator();

            var v = cc.DisplayChange(change);

            Assert.AreEqual(v.Count, lineCount);
        }

        [TestCase("£20", 2000)]
        [TestCase("£20.00", 2000)]
        [TestCase("£20.00p", 2000)]
        [TestCase("£20.10p", 2010)]
        [TestCase("£20.1", 2010)]
        [TestCase("£20.", 2000)]
        [TestCase("20", 20)]
        [TestCase("20p", 20)]
        [TestCase("20.20p", 0)]
        [TestCase("ABCD", 0)]
        [TestCase("20.20.20", 0)]
        [TestCase("£££££20.00£", 0)]
        [TestCase("12.52", 1252)]
        [TestCase("8.522", 0)]
        [TestCase("£50.p01", 0)]
        [TestCase("1£.50", 0)]
        [TestCase(".20", 20)]
        public void ConvertMoney_Various_ValidAmounts(string money, int expected)
        {
            ChangeCalculator cc = new ChangeCalculator();
            int result = cc.ConvertMoney(money);

            Assert.AreEqual(expected, result);
        }
    }
}
