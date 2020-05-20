namespace Tax.Core.Progressive
{
    public interface IHandleProgressiveTaxBracket
    {
        decimal CalculateTax(decimal annualSalary);
    }
}
