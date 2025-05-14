using TaxSystem.Models;

namespace TaxSystem.Repository
{
    public interface ITaxRepository
    {
        Task AddTaxRecord(TaxRecord taxdata);
        Task<double> GetTaxRecord(string name, DateTime dateTime);
        
    }
}
