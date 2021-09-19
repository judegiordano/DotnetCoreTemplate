namespace WebApiTemplate.Services.AppInformation
{
	public interface IAppInformation
	{
		string AppVersion { get; set; }
		string AppTitle { get; set; }
		string TermsOfServiceUrl { get; set; }
		string LicenseUrl { get; set; }
		string AppDescription { get; set; }
		string BaseUrl { get; set; }
	}
	public class AppInformation : IAppInformation
	{
		public string AppVersion { get; set; }
		public string AppTitle { get; set; }
		public string TermsOfServiceUrl { get; set; }
		public string LicenseUrl { get; set; }
		public string AppDescription { get; set; }
		public string BaseUrl { get; set; }
	}
}