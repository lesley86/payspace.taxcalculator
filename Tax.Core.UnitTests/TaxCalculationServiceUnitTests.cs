using AutoFixture;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tax.Core.Entities;
using Tax.Core.Repositories;
using Tax.Core.Services;

namespace Tax.Core.UnitTests
{
    [TestFixture]
    public class TaxCalculationServiceUnitTests
    {
        private Mock<Func<string, ITaxTypeCalculator>> mocktaxTypeCalculatorStrategy;
        private Mock<ITaxTypeCalculator> mockTaxTypeCalculator;
        private Mock<ICalculatedTaxRepostiory> mockCalculatedTaxRepostiory;
        private Fixture fixture;
        private TaxCalculationService taxCalculationService;


        [SetUp]
        public void Setup()
        {
            fixture = new Fixture();
            mocktaxTypeCalculatorStrategy = new Mock<Func<string, ITaxTypeCalculator>>();
            mockTaxTypeCalculator = new Mock<ITaxTypeCalculator>();
            mockCalculatedTaxRepostiory = new Mock<ICalculatedTaxRepostiory>();
        }


        [Test]
        public void ShouldCalculateTaxAndPerist()
        {
            var calculatedTaxEntity = new CalculatedTaxEntity("PostalCode", 5m);
            var calculatedTax = fixture.Create<decimal>();
            mocktaxTypeCalculatorStrategy.Setup(x => x.Invoke(It.IsAny<string>())).Returns(mockTaxTypeCalculator.Object);
            mockTaxTypeCalculator.Setup(x => x.CalulateTax(It.IsAny<decimal>())).Returns(calculatedTax);
            mockCalculatedTaxRepostiory.Setup(x => x.Add(It.IsAny<CalculatedTaxEntity>())).Returns(calculatedTaxEntity);

            taxCalculationService = new TaxCalculationService(mocktaxTypeCalculatorStrategy.Object, mockCalculatedTaxRepostiory.Object);
            taxCalculationService.CalculateTax(calculatedTaxEntity);

            mockCalculatedTaxRepostiory.Verify(x => x.Add(It.Is<CalculatedTaxEntity>(y => y.CalculatedTaxAmount == calculatedTax)), Times.Once);
        }
    }
}
