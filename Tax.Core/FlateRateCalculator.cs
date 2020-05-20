using Tax.Core.Exceptions;

namespace Tax.Core
{
    public class FlateRateCalculator : ITaxTypeCalculator
    {
        public decimal CalulateTax(decimal amount)
        {
            var result = 0.00m;
            if (amount == 0)
            {
                result = 0;
                return result;
            }

            if (amount < 0)
            {
                throw new InvalidFlatTaxAmountException("The ammount you entered was an invalid amount");
            }

            result = amount * 0.175m;
            return result;
        }
    }
}
