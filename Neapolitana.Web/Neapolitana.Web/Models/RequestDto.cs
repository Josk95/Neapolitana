﻿using static Neapolitana.Web.Utility.SD;

namespace Neapolitana.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public required string Url { get; set; }
        public object? Data { get; set; }
        public string AccessToken { get; set; }
    }
}
