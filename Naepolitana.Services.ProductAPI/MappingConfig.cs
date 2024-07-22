using AutoMapper;
using Naepolitana.Services.ProductAPI.Models;
using Naepolitana.Services.ProductAPI.Models.RequestObjects;
using Naepolitana.Services.ProductAPI.Models.ResponseObjects;

namespace Naepolitana.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Product, ProductResponse>();
                config.CreateMap<ProductResponse, Product>();

                config.CreateMap<ProductRequest, Product>();
            });

            return mappingConfig;
        }
    }
}
