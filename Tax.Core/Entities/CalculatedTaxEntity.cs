namespace Tax.Core.Entities
{
    public class CalculatedTaxEntity : Entity
    {
        public string PostalCode { get; private set; }

        public decimal AnnualIncome { get; private set; }

        public decimal CalculatedTaxAmount { get; set; }

        public CalculatedTaxEntity()
        {

        }

        public CalculatedTaxEntity(string postalCode, decimal annualIncome)
        {
            PostalCode = postalCode;
            AnnualIncome = annualIncome;
        }
    }
}
