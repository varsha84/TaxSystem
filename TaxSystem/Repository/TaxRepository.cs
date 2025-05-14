using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Xml.Linq;
using TaxSystem.Data;
using TaxSystem.Models;


namespace TaxSystem.Repository
{
    public class TaxRepository : ITaxRepository
    {
        private readonly AppDbContext _context;
        public TaxRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task AddTaxRecord(TaxRecord taxdata)
        {
            var value =  _context.TaxRecords.Add(taxdata);
            var result =  _context.SaveChanges();
            return Task.CompletedTask;
        }
     public async Task<double> GetTaxRecord(string name, DateTime dateTime)
     {
            var rows = await _context.TaxRecords.Where(x => x.Municipality == name && (dateTime >= x.StartDate && dateTime <= x.EndDate)).ToListAsync();
            double taxRate = 0;
            foreach (var type in Enum.GetValues(typeof(TaxType)))
            {
                foreach (var row in rows)
                {

                    if (row.TaxType.Equals(type))
                    {
                        Console.WriteLine("Two daily taxes: " + row.TaxRate);
                        taxRate = row.TaxRate;
                        return taxRate;
                    }

                }
            }
            
            return taxRate;
        }
    
    }
}