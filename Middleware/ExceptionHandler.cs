using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApiTemplate.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (ex is ApplicationException)
                {
                    await context.Response.WriteAsync(ex.Message);
                    return;
                }
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(ex.Message);
                return;
            }
        }
    }
}