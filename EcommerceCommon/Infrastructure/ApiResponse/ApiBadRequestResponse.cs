using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceCommon.Infrastructure.ApiResponse
{
    public class ApiBadRequestResponse<T> : ApiResponseNew<T>
    {
        public IEnumerable<string> Errors { get; set; }

        public ApiBadRequestResponse(string message)/* : base(400)*/
        {
            IsSuccessed = false;
            Message = message;
        }

        public ApiBadRequestResponse(IEnumerable<string> errors)
        {
            IsSuccessed = false;
            Errors = errors;
        }

        //public ApiBadRequestResponse(ModelStateDictionary modelState) : base(400)
        //{
        //    if (modelState.IsValid)
        //    {
        //        throw new ArgumentException("ModelState must be invalid", nameof(modelState));
        //    }

        //    Errors = modelState.SelectMany(x => x.Value.Errors)
        //        .Select(x => x.ErrorMessage).ToArray();
        //}
    }
}
