using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceCommon.Infrastructure.ApiResponse
{
    public class ApiOkResponse<T> : ApiResponseNew<T>
    {
        public ApiOkResponse()
        {
            IsSuccessed = true;
        }
        public ApiOkResponse(string message , T resultObj)/* : base(200)*/
        {
            IsSuccessed = true;
            Message = message;
            ResultObj = resultObj;
        }
    }
}
