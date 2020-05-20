using System;
using System.Collections.Generic;
using System.Text;
using Tax.Core.Entities;
using Tax.Core.Repositories;

namespace Tax.Persistence.EF
{
    public class CalculatedTaxRepository : BaseRepository<CalculatedTaxEntity>, ICalculatedTaxRepostiory, IDisposable
    {
        public CalculatedTaxRepository(TaxContext context) : base(context)
        {
        }
    }
}
