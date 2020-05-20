using System.Collections.Generic;

namespace Tax.Core.Progressive
{
    public class ProgressiveTaxCalculator: ITaxTypeCalculator
    {
        private readonly IEnumerable<IHandleProgressiveTaxBracket> progressiveTaxHandlers;

        public ProgressiveTaxCalculator(IEnumerable<IHandleProgressiveTaxBracket> progressiveTaxHandlers)
        {
            this.progressiveTaxHandlers = progressiveTaxHandlers;
        }

        public decimal CalulateTax(decimal annualSalary)
        {
            var result = 0.00m;
            foreach (var progressiveTaxHandler in progressiveTaxHandlers)
            {
                result += progressiveTaxHandler.CalculateTax(annualSalary);
            }

            return result;
        }
    }
}
