using Assessment.Repository.ViewModels;
using System.Net;
using System.Text.Json;

namespace Assessment.UnitConversionAPI.Middlewares
{
    /// <summary>
    /// Handling errors globally with the middleware
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        
        
        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;                       
        }

        /// <summary>
        /// Invoke when exception thrown
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);

            }
            catch (Exception ex)
            {                                
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// prepare custome error
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var message = ex.Message;

            if (ex.GetType() == typeof(UnauthorizedAccessException))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                message = $"Unauthorized - {message}";
            }

            else if (ex.GetType() == typeof(BusinessException))
            {
                context.Response.StatusCode = 200;
            }
            else 
            {
                message = "Internal Server Error";
            }

            return context.Response.WriteAsync(new ErrorLogDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }

    }

    internal class ErrorLogDetails
    {       
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
