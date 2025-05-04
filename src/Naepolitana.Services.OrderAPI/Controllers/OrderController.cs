using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Naepolitana.Services.OrderAPI.Data;
using Naepolitana.Services.OrderAPI.Models;
using Naepolitana.Services.OrderAPI.Models.RequestObject;
using Naepolitana.Services.OrderAPI.Models.ResponseObject;
using Stripe;
using Stripe.Checkout;
using static Naepolitana.Services.OrderAPI.Models.Enums;
using StripeRequest = Naepolitana.Services.OrderAPI.Models.RequestObject.StripeRequest;

namespace Naepolitana.Services.OrderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly AppDbContext _db;
        protected ResponseDto _response;
        private IMapper _mapper;

        public OrderController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        //Get Order Admin gets all. User gets users orders
        //Get Order By Id
        
        
        //Create Order
        [HttpPost("CreateOrder")]
        public async Task<ResponseDto> CreateOrder([FromBody] CartRequest cartRequest)
        {
            try
            {
                OrderRequest orderHeaderDto = _mapper.Map<OrderRequest>(cartRequest.Cart);
                orderHeaderDto.OrderTime = DateTime.Now;
                orderHeaderDto.Status = OrderStatus.Pending;
                orderHeaderDto.OrderLine = _mapper.Map<IEnumerable<OrderLineRequest>>(cartRequest.CartLines);
                orderHeaderDto.OrderTotal = Math.Round(orderHeaderDto.OrderTotal, 2);
                Order orderCreated = _db.Orders.Add(_mapper.Map<Order>(orderHeaderDto)).Entity;
                await _db.SaveChangesAsync();

                orderHeaderDto.Id = orderCreated.Id;
                _response.Result = orderHeaderDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPost("CreateStripeSession")]
        public async Task<ResponseDto> CreateStripeSession([FromBody] StripeRequest stripeRequest)
        {
            try
            {

                var options = new SessionCreateOptions
                {
                    SuccessUrl = stripeRequest.ApprovedUrl,
                    CancelUrl = stripeRequest.CancelUrl,
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",

                };

                var DiscountsObj = new List<SessionDiscountOptions>()
                {
                    new SessionDiscountOptions
                    {
                        Coupon= stripeRequest.Order.CouponCode
                    }
                };

                foreach (var item in stripeRequest.Order.OrderLine)
                {
                    var sessionLineItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)(item.Price * 100), // $20.99 -> 2099
                            Currency = "sek",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Product.Name
                            }
                        },
                        Quantity = item.Count
                    };

                    options.LineItems.Add(sessionLineItem);
                }

                if (stripeRequest.Order.Discount > 0)
                {
                    options.Discounts = DiscountsObj;
                }

                var service = new SessionService();
                Session session = service.Create(options);
                stripeRequest.StripeSessionUrl = session.Url;
                Order orderHeader = _db.Orders.First(u => u.Id == stripeRequest.Order.Id);
                orderHeader.StripeSessionId = session.Id;

                _db.SaveChanges();
                _response.Result = stripeRequest;

            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }


        [HttpPost("ValidateStripeSession")]
        public async Task<ResponseDto> ValidateStripeSession([FromBody] int orderId)
        {
            try
            {

                Order order = _db.Orders.First(u => u.Id == orderId);

                var service = new SessionService();
                Session session = service.Get(order.StripeSessionId);

                var paymentIntentService = new PaymentIntentService();
                PaymentIntent paymentIntent = paymentIntentService.Get(session.PaymentIntentId);

                if (paymentIntent.Status == "succeeded")
                {
                    //then payment was successful
                    order.PaymentIntentId = paymentIntent.Id;
                    order.Status = OrderStatus.Approved;
                    _db.SaveChanges();

                    //RewardsDto rewardsDto = new()
                    //{
                    //    OrderId = orderHeader.OrderHeaderId,
                    //    RewardsActivity = Convert.ToInt32(orderHeader.OrderTotal),
                    //    UserId = orderHeader.UserId
                    //};

                    //string topicName = _configuration.GetValue<string>("TopicAndQueueNames:OrderCreatedTopic");
                    //await _messageBus.PublishMessage(rewardsDto, topicName);
                    //_response.Result = _mapper.Map<OrderHeaderDto>(orderHeader);
                }

            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

    }
}
