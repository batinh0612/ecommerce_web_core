using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceCommon.Infrastructure.ApiResponse
{
    public class ApiResponseNew<T>
    {
        public int StatusCode { get; set; }

        public bool IsSuccessed { get; set; }

        public T ResultObj { get; set; }

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        //public ApiResponseNew(int statusCode, string message = null)
        //{
        //    StatusCode = statusCode;
        //    Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        //}

        //private static string GetDefaultMessageForStatusCode(int statusCode)
        //{
        //    switch (statusCode)
        //    {

        //        case 404:
        //            return "Resource not found";
        //        case 500:
        //            return "An unhandled error occurred";
        //        default:
        //            return null;
        //    }
        //}
    }
}
