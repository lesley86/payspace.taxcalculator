namespace Tax.Core.Progressive
{
    public class Handle28PercentTaxBracket : ProgressiveCalculationBase, IHandleProgressiveTaxBracket
    {
        public override decimal UpperLimitForTaxBrakcet => 171550m;

        public override decimal LowerLimitForTaxBrakcet => 82251m;

        public override decimal RateForThisTaxBracket => 0.28m;
      
    }
}
