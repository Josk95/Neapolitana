using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Naepolitana.Services.ProductAPI.Data;
using Naepolitana.Services.ProductAPI.Models;
using Naepolitana.Services.ProductAPI.Models.RequestObjects;
using Naepolitana.Services.ProductAPI.Models.ResponseObjects;
using Neapolitana.Services.CouponAPI.Models.ResponseObjects;
using Stripe;

namespace Naepolitana.Services.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _responseDto;
        private readonly IMapper _mapper;


        public ProductController(AppDbContext db, IMapper mapper)
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
                IEnumerable<Models.Product> coupons = _db.Products.ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<ProductResponse>>(coupons);

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
                var coupon = _db.Products.First(x => x.Id == id);
                _responseDto.Result = _mapper.Map<ProductResponse>(coupon);

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
        public ActionResult<ResponseDto> Create(ProductRequest request)
        {
            try
            {
                var coupon = _mapper.Map<Models.Product>(request);

                _db.Products.Add(coupon);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<ProductResponse>(coupon);

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
        public ActionResult<ResponseDto> Update(int id, ProductRequest request)
        {
            try
            {
                var coupon = _mapper.Map<Models.Product>(request);
                coupon.Id = id;

                _db.Products.Update(coupon);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<ProductResponse>(coupon);

                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
                return BadRequest(_responseDto);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult<ResponseDto> Delete(int id)
        {
            try
            {
                Models.Product coupon = _db.Products.First(x => x.Id == id);

                _db.Products.Remove(coupon);
                _db.SaveChanges();

                var service = new CouponService();

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
