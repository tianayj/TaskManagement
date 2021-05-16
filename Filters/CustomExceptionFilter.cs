using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace TaskManager.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {


            HttpStatusCode statusCode;
            String errorMessage = "";

            var exceptionType = context.Exception.GetType();
            if(context.Exception is UnauthorizedAccessException)
            {
                errorMessage = "Unauthorized access! Please check your Bearer Token if you have one";
                statusCode = HttpStatusCode.Unauthorized;

            }
            else
            {
                errorMessage = "Sorry, internal server error. Something went wrong";
                statusCode = HttpStatusCode.InternalServerError;
            }
            context.Response = context.Request.CreateErrorResponse(statusCode, errorMessage);
            base.OnException(context);
        }
    }
}