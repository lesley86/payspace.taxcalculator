namespace Tax.Core.Progressive
{
    public class Handle35PercentTaxBracket : ProgressiveCalculationBase, IHandleProgressiveTaxBracket
    {
        public override decimal UpperLimitForTaxBrakcet => decimal.MaxValue;

        public override decimal LowerLimitForTaxBrakcet => 372951m;

        public override decimal RateForThisTaxBracket => 0.35m;

    }
}
