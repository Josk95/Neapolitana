namespace Naepolitana.Services.OrderAPI.Models.RequestObject
{
    public class OrderLineRequest
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public required ProductRequest Product { get; set; }
        public int Count { get; set; }
        public required string ProductName { get; set; }
        public double Price { get; set; }
    }
}
