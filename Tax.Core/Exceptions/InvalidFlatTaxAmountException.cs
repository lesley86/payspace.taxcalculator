using System;

namespace Tax.Core.Exceptions
{
    public class InvalidFlatTaxAmountException : Exception
    {
        public InvalidFlatTaxAmountException(string message) : base(message)
        {

        }
    }
}
