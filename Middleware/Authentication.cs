using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApiTemplate.Middleware.Abstract;

namespace WebApiTemplate.Middleware
{
    public class Authentication
    {
        private readonly RequestDelegate _next;
        private IAppCodeValidation _keys { get; set; }

        public Authentication(RequestDelegate next, IAppCodeValidation keys)
        {
            _next = next;
            _keys = keys;
        }

        public async Task Invoke(HttpContext context)
        {
            string appCode = context.Request.Headers["APPCODE"].ToString();

            if (appCode != _keys.AppCode)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Access denied");
                return;
            }
            await _next(context);
        }
    }
}