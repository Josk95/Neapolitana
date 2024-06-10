using Neapolitana.Core.Lib.Entity;

namespace Neapolitana.Services.CouponAPI.Models
{
    public class Coupon : BaseEntity
    {
        public required string Code { get; set; }
        public required double Discount { get; set; }
        public int? MinimumAmount { get; set; }
    }
}
