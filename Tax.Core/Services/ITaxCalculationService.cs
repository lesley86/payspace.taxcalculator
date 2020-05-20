using System;
using Tax.Core.Entities;

namespace Tax.Core.Services
{
    public interface ITaxCalculationService
    {
        Guid CalculateTax(CalculatedTaxEntity calculatedTaxEntity);
    }
}