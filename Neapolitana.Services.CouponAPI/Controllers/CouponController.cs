using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Neapolitana.Services.CouponAPI.Data;
using Neapolitana.Services.CouponAPI.Models;
using Neapolitana.Services.CouponAPI.Models.RequestObject;
using Neapolitana.Services.CouponAPI.Models.ResponseObjects;

namespace Neapolitana.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _responseDto;
        private readonly IMapper _mapper;

        public CouponController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _responseDto = new ResponseDto();
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<ResponseDto> Get()
        {
            try
            {
                IEnumerable<Coupon> coupons = _db.Coupons.ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<CouponResponse>>(coupons);

                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
                return BadRequest(_responseDto);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<ResponseDto> GetById(int id)
        {
            try
            {
                var coupon =  _db.Coupons.First(x => x.Id == id);
                _responseDto.Result = _mapper.Map<CouponResponse>(coupon);

                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
                return BadRequest(_responseDto);
            }
        }

        [HttpGet]
        [Route("Code/{code}")]
        public ActionResult<ResponseDto> GetByCode(string code)
        {
            try
            {
                var coupon = _db.Coupons.FirstOrDefault(x => x.Code.ToLower() == code.ToLower());
                                
                _responseDto.Result = _mapper.Map<CouponResponse>(coupon);

                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
                return BadRequest(_responseDto);
            }
        }

       
        [HttpPost]
        public ActionResult<ResponseDto> Create(CouponRequest request)
        {
            try
            {
                var coupon = _mapper.Map<Coupon>(request);

                _db.Coupons.Add(coupon);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<CouponResponse>(coupon);

                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
                return BadRequest(_responseDto);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult<ResponseDto> Update(int id, CouponRequest request)
        {
            try
            {
                var coupon = _mapper.Map<Coupon>(request);
                coupon.Id = id;

                _db.Coupons.Update(coupon);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<CouponResponse>(coupon);

                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
                return BadRequest(_responseDto);
            }
        }

        //[HttpDelete] - Update Coupon
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult<ResponseDto> Delete(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(x => x.Id == id);

                _db.Coupons.Remove(coupon);
                _db.SaveChanges();


                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
                return BadRequest(_responseDto);
            }
        }
    }
}
