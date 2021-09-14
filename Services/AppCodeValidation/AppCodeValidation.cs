namespace WebApiTemplate.Middleware.Abstract
{
    public interface IAppCodeValidation
    {
        string AppCode { get; set; }
    }
    public class AppCodeValidation : IAppCodeValidation
    {
        public string AppCode { get; set; }
    }
}