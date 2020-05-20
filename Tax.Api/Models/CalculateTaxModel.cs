using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tax.Api.Models
{
    public class CalculateTaxModel
    {
        public string PostalCode { get; set; }

        public decimal AnnualIncome { get; set; }
    }
}
