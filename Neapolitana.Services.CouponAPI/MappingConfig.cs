using AutoMapper;
using Neapolitana.Services.CouponAPI.Models;
using Neapolitana.Services.CouponAPI.Models.RequestObject;
using Neapolitana.Services.CouponAPI.Models.ResponseObjects;

namespace Neapolitana.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Coupon,CouponResponse>();
                config.CreateMap<CouponResponse, Coupon>();

                config.CreateMap<CouponRequest, Coupon>();
            });

            return mappingConfig;
        }
    }
}
