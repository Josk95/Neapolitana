namespace Neapolitana.Services.CouponAPI.Models.RequestObject
{
    public class CouponRequest
    {
        public required string Code { get; set; }
        public required double Discount { get; set; }
        public int? MinimumAmount { get; set; }
    }
}
