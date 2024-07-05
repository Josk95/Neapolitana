using Neapolitana.Web.Models;
using Neapolitana.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;

namespace Neapolitana.Web.Service
{
    public class BaseService : IBaseService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("NeapolitanaAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                //Token later on

                message.RequestUri = new Uri(requestDto.Url);

                if (requestDto != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage response = null;

                message.Method = requestDto.ApiType switch
                {
                    Utility.SD.ApiType.GET => HttpMethod.Get,
                    Utility.SD.ApiType.POST => HttpMethod.Post,
                    Utility.SD.ApiType.PUT => HttpMethod.Put,
                    Utility.SD.ApiType.DELETE => HttpMethod.Delete,
                    _ => throw new NotImplementedException(),
                };

                response = await client.SendAsync(message);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        {
                            return new() { IsSuccess = false, Message = "Not Found" };
                        }
                    case HttpStatusCode.Forbidden:
                        {
                            return new() { IsSuccess = false, Message = "Access Denied" };
                        }
                    case HttpStatusCode.Unauthorized:
                        {
                            return new() { IsSuccess = false, Message = "Unauthorized" };
                        }
                    case HttpStatusCode.InternalServerError:
                        {
                            return new() { IsSuccess = false, Message = "Internal Server Error" };
                        }
                    default:
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var responseDto = JsonConvert.DeserializeObject<ResponseDto>(responseContent);
                        return responseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto()
                {
                    IsSuccess = false,
                    Message = ex.Message.ToString()
                };

                return dto;
            }
            
        }
    }
}
