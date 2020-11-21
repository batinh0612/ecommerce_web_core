using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebAPI.Infrastructure.Wrappers
{
    public class ApiError
    {
        public string ExceptionMessage { get; set; }
        public string Details { get; set; }
        public string ReferenceErrorCode { get; set; }
        public string ReferenceDocumentLink { get; set; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        public ApiError()
        {

        }

        public ApiError(string message)
        {
            this.ExceptionMessage = message;
        }

        public ApiError(string message, IEnumerable<ValidationError> validationErrors)
        {
            this.ExceptionMessage = message;
            this.ValidationErrors = validationErrors;

        }
    }
}
