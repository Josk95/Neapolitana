using Naepolitana.Services.OrderAPI.Models.RequestObject;
using Naepolitana.Services.OrderAPI.Models.ResponseObject;

namespace Naepolitana.Services.OrderAPI.Models
{
    public class CartLine
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart? Cart { get; set; }
        public int ProductId { get; set; }
        public ProductRequest? Product { get; set; }
        public int Count { get; set; }

    }
}
