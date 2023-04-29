using Newtonsoft.Json;
using System.Net;
using TechSol.StudentManagementSystem.Utility.Exceptions;
using Sentry;

namespace TechSol.StudentManagementSystem.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case AppException:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case NotImplementedException:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotImplemented;
                        break;

                    case UnauthorizedAccessException:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;


                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                SentrySdk.CaptureException(error);
                var result = JsonConvert.SerializeObject(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
