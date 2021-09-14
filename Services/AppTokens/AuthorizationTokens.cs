namespace WebApiTemplate.Services.Apptokens
{
    public interface IAuthorizationTokens
    {
        string DeveloperToken { get; set; }
        string ExampleClientAToken { get; set; }
    }
    public class AuthorizationTokens : IAuthorizationTokens
    {
        public string DeveloperToken { get; set; }
        public string ExampleClientAToken { get; set; }
    }
}