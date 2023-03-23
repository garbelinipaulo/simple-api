using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data.SqlClient;
using System.Net;

namespace Product.API.Filters
{


    /// <summary>
    /// This is a pattern that I use for handling exceptions without need to set them into service layer
    /// </summary>
    public class ExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context != null && context.Exception != null)
            {
                var exception = context.Exception;
                var exceptionType = exception.GetType();
                var exceptionDetails = exception.ToString();
                HttpStatusCode status = HttpStatusCode.InternalServerError;
                var message = exceptionDetails.ToString(); 

                if (exceptionType == typeof(Exception))
                    message = "Generic Exception happened!";

                var _response = new
                {
                    ErrorCode = (int)status,
                    ErroMessage = message
                };

                context.Result = new ObjectResult(_response)
                {
                    StatusCode = _response.ErrorCode
                };

                context.ExceptionHandled = true;
            }
        }


    }
}
