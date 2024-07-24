namespace Naepolitana.Services.OrderAPI.Models.RequestObject
{
    public class StripeRequest
    {
        public string? StripeSessionUrl { get; set; }
        public string? StripeSessionId { get; set; }
        public required string ApprovedUrl { get; set; }
        public required string CancelUrl { get; set; }
        public OrderRequest Order { get; set; }
    }
}
