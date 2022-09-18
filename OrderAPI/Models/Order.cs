namespace OrderAPI.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Qty { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
