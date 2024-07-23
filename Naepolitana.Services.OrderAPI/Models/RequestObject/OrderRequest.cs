using static Naepolitana.Services.OrderAPI.Models.Enums;

namespace Naepolitana.Services.OrderAPI.Models.RequestObject
{
    public class OrderRequest
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? CouponCode { get; set; }
        public double Discount { get; set; }
        public double OrderTotal { get; set; }


        public string? Name { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
        public DateTime OrderTime { get; set; }
        public OrderStatus? Status { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? StripeSessionId { get; set; }
        public IEnumerable<OrderLineRequest> OrderLine { get; set; }
    }
}
