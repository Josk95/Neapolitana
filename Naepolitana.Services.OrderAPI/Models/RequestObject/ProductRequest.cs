﻿namespace Naepolitana.Services.OrderAPI.Models.RequestObject
{
    public class ProductRequest
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }
        public required string Description { get; set; }
        public required string CategoryName { get; set; }
        public required string ImageUrl { get; set; }

        public int Count { get; set; } = 1;
    }
}
