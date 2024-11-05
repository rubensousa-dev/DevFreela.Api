using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;


namespace DevFreela.API.ExceptionHandler
{
    public class ApiExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "server error"
            };


            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);
            return true;
        }
    }
}
