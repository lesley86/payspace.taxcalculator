using System;

namespace Tax.Core.Progressive
{
    public abstract class ProgressiveCalculationBase
    {
        public abstract decimal UpperLimitForTaxBrakcet { get; }
        public abstract decimal LowerLimitForTaxBrakcet { get; }
        public abstract decimal RateForThisTaxBracket { get; }

        public decimal CalculateTax(decimal annualsalary)
        {
            var result = 0.00m;
            if (annualsalary >= LowerLimitForTaxBrakcet)
            {
                var taxableAmount = Math.Min(UpperLimitForTaxBrakcet - LowerLimitForTaxBrakcet, annualsalary - LowerLimitForTaxBrakcet);
                result = taxableAmount * RateForThisTaxBracket;
            }

            return result;
        }
    }
}
