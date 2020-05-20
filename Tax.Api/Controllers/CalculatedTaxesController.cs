using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tax.Api.Models;
using Tax.Core.Entities;
using Tax.Core.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tax.Api.Controllers
{
    [ApiController]
    [Route("[controller]/calculatedtaxes")]
    public class CalculatedTaxesController : Controller
    {
        private readonly ITaxCalculationService calculationService;

        public CalculatedTaxesController(ITaxCalculationService calculationService)
        {
            this.calculationService = calculationService;
        }

        [HttpPost]
        public IActionResult AddNewTaxCalculation(CalculateTaxModel calculateTaxCommand)
        {
            var entity = new CalculatedTaxEntity(calculateTaxCommand.PostalCode, calculateTaxCommand.AnnualIncome);
            calculationService.CalculateTax(entity);
            return Ok();
        }
    }
}
