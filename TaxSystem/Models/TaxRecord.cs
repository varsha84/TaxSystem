namespace TaxSystem.Models
{
    public enum TaxType
    {
        Daily,
        Weekly,
        Monthly,
        Yearly
    }
    public class TaxRecord
    {
        public int Id { get; set; }
        public string? Municipality { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TaxRate { get; set; }
        public TaxType TaxType { get; set; }


    }

}
