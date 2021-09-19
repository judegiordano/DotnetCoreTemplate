using System.ComponentModel.DataAnnotations;

namespace WebApiTemplate.Maps
{
	public static class Abstract
	{
		public class Register
		{
			[Required]
			public string Username { get; set; }

			[Required]
			[DataType(DataType.EmailAddress)]
			public string Email { get; set; }

			[Required]
			[DataType(DataType.Password)]
			public string Password { get; set; }
		}

		public class Login
		{
			[Required]
			public string Username { get; set; }

			[Required]
			[DataType(DataType.Password)]
			public string Password { get; set; }
		}
	}
}