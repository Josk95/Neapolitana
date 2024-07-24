using Naepolitana.Services.OrderAPI.Models.ResponseObject;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naepolitana.Services.OrderAPI.Models
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
        public int ProductId { get; set; }

        [NotMapped]
        public ProductResponse? Product { get; set; }
        public int Count { get; set; }
        public required string ProductName { get; set; }
        public double Price { get; set; }

    }
}
