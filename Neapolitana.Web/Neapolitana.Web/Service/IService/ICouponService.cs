using Neapolitana.Web.Models;

namespace Neapolitana.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponByCodeAsync(string couponCode);
        Task<ResponseDto?> GetAllCouponAsync();
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> CreateCouponAsync(CouponDTO request);
        Task<ResponseDto?> UpdateCouponAsync(CouponDTO request);
        Task<ResponseDto?> DeleteCouponAsync(int id);

    }
}
