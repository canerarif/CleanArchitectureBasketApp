using BasketApp.Application.Wrappers;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace BasketApp.Application.Exceptions
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(RequestDelegate Next)
        {
            next = Next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case Exception:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new ServiceResponse<Exception>(error.InnerException) { IsSuccess = false, ErrorMessage = error.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
