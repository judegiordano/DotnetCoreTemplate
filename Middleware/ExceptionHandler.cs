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
                await context.Response.WriteAsJsonAsync(new ErrorResponse
                {
                    Ok = false,
                    Status = context.Response.StatusCode,
                    Message = ex.Message
                });
                return;
            }
        }

        public class ErrorResponse
        {
            public bool Ok { get; set; }
            public int Status { get; set; }
            public string Message { get; set; }
        }
    }
}