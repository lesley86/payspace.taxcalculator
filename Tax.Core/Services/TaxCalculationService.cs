using System;
using Tax.Core.Entities;
using Tax.Core.Exceptions;
using Tax.Core.Repositories;

namespace Tax.Core.Services
{
    public class TaxCalculationService : ITaxCalculationService
    {
        private readonly Func<string, ITaxTypeCalculator> taxTypeCalculatorStrategy;
        private readonly ICalculatedTaxRepostiory calculatedTaxRepostiory;

        public TaxCalculationService(
            Func<string, ITaxTypeCalculator> taxTypeCalculatorStrategy,
            ICalculatedTaxRepostiory calculatedTaxRepostiory)
        {
            this.taxTypeCalculatorStrategy = taxTypeCalculatorStrategy;
            this.calculatedTaxRepostiory = calculatedTaxRepostiory;
        }

        public Guid CalculateTax(CalculatedTaxEntity calculatedTaxEntity)
        {
            ValidateEntityIntegrity(calculatedTaxEntity);
            var taxTypeCalculator = TaxTypeCalculator(calculatedTaxEntity, taxTypeCalculatorStrategy);
            var savedEntity = PersistCalculatedTax(CalulateTaxAnPopulateEntity(calculatedTaxEntity, taxTypeCalculator));
            return savedEntity.Id;
        }

        private CalculatedTaxEntity PersistCalculatedTax(CalculatedTaxEntity calculatedTaxEntity)
        {
            var savedEntity = calculatedTaxRepostiory.Add(calculatedTaxEntity);
            calculatedTaxRepostiory.SaveChanges();
            return savedEntity;
        }

        private static CalculatedTaxEntity CalulateTaxAnPopulateEntity(CalculatedTaxEntity calculatedTaxEntity, ITaxTypeCalculator taxTypeCalculator)
        {
            var calculatedTaxAmount = taxTypeCalculator.CalulateTax(calculatedTaxEntity.AnnualIncome);
            calculatedTaxEntity.CalculatedTaxAmount = calculatedTaxAmount;
            return calculatedTaxEntity;
        }

        private static ITaxTypeCalculator TaxTypeCalculator(CalculatedTaxEntity calculatedTaxEntity, Func<string, ITaxTypeCalculator> taxTypeCalculatorStrategy)
        {
            var taxTypeCalculator = taxTypeCalculatorStrategy.Invoke(calculatedTaxEntity.PostalCode);
            if (taxTypeCalculator == null)
            {
                throw new ValidationException($"The postal code of {calculatedTaxEntity.PostalCode} is not known.");
            }

            return taxTypeCalculator;
        }

        private static void ValidateEntityIntegrity(CalculatedTaxEntity calculatedTaxEntity)
        {
            if (calculatedTaxEntity.AnnualIncome < 0)
            {
                throw new ValidationException("Annaul Income cannot be less than 0");
            }

            if (string.IsNullOrWhiteSpace(calculatedTaxEntity.PostalCode))
            {
                throw new ValidationException("Postal Code Cannot be empty");
            }
        }

    }
}
