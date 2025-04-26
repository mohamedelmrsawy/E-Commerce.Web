using DomianLayer.Exceptions;
using Shared.ErrorModels;

namespace E_Commerce.Web.CustomMiddleWare
{
    public class CustomExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleWare> _logger;

        public CustomExceptionMiddleWare(RequestDelegate next , ILogger<CustomExceptionMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }catch (Exception ex)
            {
                _logger.LogError(ex, "!!!!!!!!!!!");

                // httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                httpContext.Response.StatusCode = ex switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };

                //httpContext.Response.ContentType = "application/json";

                var Response = new ErrorToReturn()
                {
                    //StatusCode = StatusCodes.Status500InternalServerError,
                    StatusCode = httpContext.Response.StatusCode,
                    ErrorMessage = ex.Message
                };

                await httpContext.Response.WriteAsJsonAsync(Response);  

            }
        }


    }
}
