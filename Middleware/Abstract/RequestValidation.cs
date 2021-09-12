namespace WebApiTemplate.Middleware.Abstract
{
    public interface IRequestValidation
    {
        string AppCode { get; set; }
    }
    public class RequestValidation : IRequestValidation
    {
        public string AppCode { get; set; }
    }
}