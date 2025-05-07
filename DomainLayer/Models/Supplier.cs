namespace DomainLayer.Models
{
    public partial class Supplier
    {
        public int SupplierId { get; set; }

        public string SupplierName { get; set; } = null!;

        public string? ContactPerson { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; } //= new List<Stock>();

    }
}