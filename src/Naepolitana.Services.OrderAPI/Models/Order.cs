using static Naepolitana.Services.OrderAPI.Models.Enums;

namespace Naepolitana.Services.OrderAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? UserId  { get; set; }
        public string? CouponCode { get; set; }
        public double Discount { get; set; } 
        public double OrderTotal { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public required string Email { get; set; }
        public DateTime OrderTime { get; set; }
        public required OrderStatus Status { get; set; }
        public string? StripeSessionId { get; set; }
        public string? PaymentIntentId { get; set; }
        public required IEnumerable<OrderLine> OrderLines { get; set; }

    }
}
