using Microsoft.AspNetCore.Mvc;
using TaxSystem.Models;
using TaxSystem.Repository;

namespace TaxSystem.Controllers
{
    public class MunicipalityTaxController : Controller
    {
        private ITaxRepository _taxRepository;
        public MunicipalityTaxController(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        /// <summary>
        /// Add new Muncipality Tax Record 
        /// </summary>
        /// <param taxRecord="TaxRecord">TaxRecord</param>
        /// <response code="200">Returns Success</response>
        [HttpPost("AddTaxRecord")]
        public void AddTaxRecord([FromBody] TaxRecord taxRecord)
        {
            _taxRepository.AddTaxRecord(taxRecord);
        }
        
        /// <summary>
        /// Get tax rates for a specific municipality on a given date
        /// </summary>
        /// <param name="string">Name of Municipality</param>
        /// <param date="DateTime">Date</param>
        /// <response code="200">Returns TaxRate</response>
        [HttpGet("GetTaxRate")]
        public async Task<double> GetTaxRate(string name, DateTime date)
        {
            return await _taxRepository.GetTaxRecord(name, date);
        }

    }
}
