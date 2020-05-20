namespace Tax.Core
{
    public interface ITaxTypeCalculator
    {
        decimal CalulateTax(decimal annualSalary);
    }
}
