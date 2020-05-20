namespace Tax.Core.Progressive
{
    public class Handle25PercentTaxBracket : ProgressiveCalculationBase, IHandleProgressiveTaxBracket
    {
        public override decimal UpperLimitForTaxBrakcet => 82250m ;

        public override decimal LowerLimitForTaxBrakcet => 33951m;

        public override decimal RateForThisTaxBracket => 0.25m;
    }
}
