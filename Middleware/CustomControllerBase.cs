using Microsoft.AspNetCore.Mvc;

namespace WebApiTemplate.Middleware
{
	public class CustomControllerBase : ControllerBase
	{
		public override OkObjectResult Ok(object value)
		{
			return new OkObjectResult(new DataReponse
			{
				ok = true,
				status = 200,
				data = value
			});
		}
	}
	public class DataReponse
	{
		public bool ok { get; set; }
		public int status { get; set; }
		public object data { get; set; }
	}
}