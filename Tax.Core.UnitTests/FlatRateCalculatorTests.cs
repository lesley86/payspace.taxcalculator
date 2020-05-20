using NUnit.Framework;
using Tax.Core;
using Tax.Core.Exceptions;

namespace Tax_Core.UnitTests
{
    [TestFixture]
    public class FlatRateCalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldRetur17AndAHalfPercentForAllValidAmounts()
        {
            var calculator = new FlateRateCalculator();
            var result = calculator.CalulateTax(10000);
            Assert.AreEqual(1750m, result);
        }

        [Test]
        public void ShouldReturn0WhenAMountIs0()
        {
            var calculator = new FlateRateCalculator();
            var result = calculator.CalulateTax(0);
            Assert.AreEqual(0m, result);

        }

        [Test]
        public void ShouldThrowInvalidAmountExcetionWhenANegativeAmount()
        {
            var calculator = new FlateRateCalculator();

            Assert.Throws<InvalidFlatTaxAmountException>(() => calculator.CalulateTax(-200000));
        }
    }
}