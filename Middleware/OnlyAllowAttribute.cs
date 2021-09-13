using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiTemplate.Services.AuthConsumer;

namespace WebApiTemplate.Middleware
{
    public class OnlyAllowAttribute : TypeFilterAttribute
    {
        public OnlyAllowAttribute(AuthConsumers.Consumer value) : base(typeof(OnlyAllowFilter))
        {
            Arguments = new object[] { value };
        }
    }

    public class OnlyAllowFilter : IAuthorizationFilter
    {
        private AuthConsumers.Consumer _value { get; set; }

        public OnlyAllowFilter(AuthConsumers.Consumer value)
        {
            _value = value;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                string token = context.HttpContext.Request.Headers["APPTOKEN"];
                if (token == null)
                {
                    context.HttpContext.Response.StatusCode = 401;
                    throw new Exception("unauthorized");
                }
                string auth = AuthConsumers.Consumers[_value];
                if(auth != token)
                {
                    context.HttpContext.Response.StatusCode = 401;
                    throw new Exception("elevation required");
                }
                return;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}