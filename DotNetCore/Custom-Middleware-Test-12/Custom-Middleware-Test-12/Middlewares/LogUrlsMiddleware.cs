using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Custom_Middleware_Test_12.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LogUrlsMiddleware
    {
        private readonly RequestDelegate _next;

        public LogUrlsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine(string.Format("Processing request{0}", httpContext.Request.Host + httpContext.Request.Path));
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LogUrlsMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogUrlsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogUrlsMiddleware>();
        }
    }
}
