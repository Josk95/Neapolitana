namespace Naepolitana.Services.OrderAPI.Models.RequestObject
{
    public class CartRequest
    {
        public required Cart Cart { get; set; }
        public IEnumerable<CartLine>? CartLines { get; set; }
    }
}
