using Microsoft.AspNetCore.Mvc;

namespace WebApiTemplate.Middleware
{
    public class RouterAttribute : RouteAttribute
    {
        public static string baseUrl { get; set; }
        public RouterAttribute(string template) : base($"{baseUrl}/{template}/")
        {
        }
    }
}