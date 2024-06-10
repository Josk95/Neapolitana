namespace Neapolitana.Services.CouponAPI.Models.ResponseObjects
{
    public class CouponResponse
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public required double Discount { get; set; }
        public int? MinimumAmount { get; set; }
    }
}
