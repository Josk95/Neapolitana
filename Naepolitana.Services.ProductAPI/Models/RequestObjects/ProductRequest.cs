namespace Naepolitana.Services.ProductAPI.Models.RequestObjects
{
    public class ProductRequest
    {
        public required string Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageLocalPath { get; set; }
    }
}
