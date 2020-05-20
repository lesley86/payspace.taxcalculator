using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tax.Core.Progressive;

namespace Tax.Core.UnitTests
{
    [TestFixture]
    public class ProgressiveTaxCalculationHandlerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldReturn10InPercentageRange()
        {
            var calculator = new Handle10PercentTaxBracket();
            var result = calculator.CalculateTax(8350);
            Assert.AreEqual(835m, result);
        }

        [Test]
        public void ShouldReturn15PercentInPercentageRange()
        {
            var calculator = new Handle15PercentTaxBracket();
            var result = calculator.CalculateTax(33950m);
            Assert.AreEqual(3839.85m, result);
        }

        [Test]
        public void ShouldReturn25PercentInPercentageRange()
        {
            var calculator = new Handle25PercentTaxBracket();
            var result = calculator.CalculateTax(82250m);
            Assert.AreEqual(12074.75m, result);
        }

        [Test]
        public void ShouldReturn28PercentInPercentageRange()
        {
            var calculator = new Handle28PercentTaxBracket();
            var result = calculator.CalculateTax(171550m);
            Assert.AreEqual(25003.72m, result);
        }

        [Test]
        public void ShouldReturn33PercentInPercentageRange()
        {
            var calculator = new Handle33PercentTaxBracket();
            var result = calculator.CalculateTax(decimal.Parse("372950"));
            Assert.AreEqual(66461.67m, result);
        }
        [Test]
        public void ShouldReturn35PercenttInPercentageRange()
        {
            var calculator = new Handle35PercentTaxBracket();
            var result = calculator.CalculateTax(decimal.Parse("372952"));
            Assert.AreEqual(0.35m, result);
        }
    }
}
