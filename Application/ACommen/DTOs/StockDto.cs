namespace ApplicationLayer.ACommen.DTOs
{
    public class StockDTO
    {
        public int StockId { get; set; }
        public int ItemId { get; set; }
        public int SupplierId { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime ReceivedDate { get; set; }
    }
}
