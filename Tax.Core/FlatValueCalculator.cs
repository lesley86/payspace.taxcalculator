using Tax.Core.Exceptions;

namespace Tax.Core
{
    public class FlatValueCalculator : ITaxTypeCalculator
    {
        public decimal CalulateTax(decimal amount)
        {
            var result = 0.00m;
            if (amount == 0)
            {
                result = 0;
                return result;
            }

            if (amount > 0 && amount < 200000)
            {
                result = amount * 0.05m;
                return result;
            }

            if(amount >= 200000)
            {
                result = 10000;
                return result;
            }

            throw new InvalidFlatTaxAmountException("The ammount you entered was an invalid amount");
        }
    }
}
