using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tax.Core.Progressive;

namespace Tax.Core.UnitTests
{
    [TestFixture]
    public class ProgressiveTaxCalulatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldCalculateAmountForAllTaxBrackets()
        {
            var calculator = new ProgressiveTaxCalculator(new List<IHandleProgressiveTaxBracket>
            {
                 new Handle10PercentTaxBracket(),
                 new Handle15PercentTaxBracket(),
                 new Handle25PercentTaxBracket(),
                 new Handle28PercentTaxBracket(),
                 new Handle33PercentTaxBracket(),
                 new Handle35PercentTaxBracket() 
            });
  
            var result = calculator.CalulateTax(372952m);
            Assert.AreEqual(108215.34m, result);
        }
    }
}
