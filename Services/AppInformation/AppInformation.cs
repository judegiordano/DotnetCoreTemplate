namespace WebApiTemplate.Services.AppInformation
{
    public interface IAppInformation
    {
        string AppVersion { get; set; }
        string AppTitle { get; set; }
    }
    public class AppInformation : IAppInformation
    {
        public string AppVersion { get; set; }
        public string AppTitle { get; set; }
    }
}