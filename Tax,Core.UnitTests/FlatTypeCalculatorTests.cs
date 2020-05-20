using NUnit.Framework;
using Tax.Core;
using Tax.Core.Exceptions;

namespace Tax_Core.UnitTests
{
    [TestFixture]
    public class FlatTypeCalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldReturn5PercentWhenAmountBelow200000()
        {
            var calculator = new FlatTaxCalculator();
            var result = calculator.CalulateTax(19999);
            Assert.AreEqual(999.95m, result);
        }

        [Test]
        public void ShouldReturn100000WhenAmountEqualToOrAbove200000()
        {
            var calculator = new FlatTaxCalculator();
            var result = calculator.CalulateTax(200000);
            Assert.AreEqual(10000m, result);
        }

        [Test]
        public void ShouldReturn0WhenAMountIs0()
        {
            var calculator = new FlatTaxCalculator();
            var result = calculator.CalulateTax(200000);
            Assert.AreEqual(0m, result);

        }

        [Test]
        public void ShouldThrowInvalidAmountExcetionWhenANegativeAmount()
        {
            var calculator = new FlatTaxCalculator();

            Assert.Throws<InvalidFlatTaxAmountException>(() => calculator.CalulateTax(-200000));
        }
    }
}