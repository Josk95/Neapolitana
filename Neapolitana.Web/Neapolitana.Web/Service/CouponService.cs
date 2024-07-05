using Neapolitana.Web.Models;
using Neapolitana.Web.Service.IService;
using Neapolitana.Web.Utility;

namespace Neapolitana.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateCouponAsync(CouponDTO request)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = SD.CouponAPIBase! + "/api/coupon/",
                Data = request
            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CouponAPIBase! + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto?> GetAllCouponAsync()
        {
            return await _baseService.SendAsync(new RequestDto() 
            { 
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase! + "/api/coupon"
            });
        }

        public async Task<ResponseDto?> GetCouponByCodeAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase! + "/api/coupon/Code/" + couponCode
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase! + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDTO request)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Url = SD.CouponAPIBase! + "/api/coupon/",
                Data = request
            });
        }
    }
}
