namespace Tax.Core.Progressive
{
    public class Handle33PercentTaxBracket : ProgressiveCalculationBase, IHandleProgressiveTaxBracket
    {
        public override decimal UpperLimitForTaxBrakcet => 372950m;

        public override decimal LowerLimitForTaxBrakcet => 171551m;

        public override decimal RateForThisTaxBracket => 0.33m;

    }
}
