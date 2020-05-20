namespace Tax.Core.Progressive
{
    public class Handle15PercentTaxBracket : ProgressiveCalculationBase, IHandleProgressiveTaxBracket
    {
        public override decimal UpperLimitForTaxBrakcet => 33950m;

        public override decimal LowerLimitForTaxBrakcet => 8351m;

        public override decimal RateForThisTaxBracket => 0.15m;

    }
}
