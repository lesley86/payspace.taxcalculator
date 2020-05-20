namespace Tax.Core
{
    public interface ITaxTypeCalculatorProvider
    {
        ITaxTypeCalculator Get(string postalCode);
    }
}
