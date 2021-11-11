using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ConsoleToWEBApi
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("custom middle - 1 \n");
            await next(context);
            await context.Response.WriteAsync("custom middle  1 \n");

        }
    }
}