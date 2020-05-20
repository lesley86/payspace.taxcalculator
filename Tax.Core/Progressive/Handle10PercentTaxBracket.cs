namespace Tax.Core.Progressive
{
    public class Handle10PercentTaxBracket : ProgressiveCalculationBase, IHandleProgressiveTaxBracket
    {
        public override decimal UpperLimitForTaxBrakcet => 8350m;

        public override decimal LowerLimitForTaxBrakcet => 0m;

        public override decimal RateForThisTaxBracket => 0.10m;

    }
}
