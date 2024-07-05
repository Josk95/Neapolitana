namespace Neapolitana.Web.Models;
public class CouponDTO
{
    public int Id { get; set; }
    public required string Code { get; set; }
    public required double Discount { get; set; }
    public int? MinimumAmount { get; set; }
}

