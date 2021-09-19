using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Models.Shared;

namespace WebApiTemplate.Models
{
	[Index(nameof(Username), IsUnique = true)]
	[Index(nameof(Email), IsUnique = true)]
	public class User : Base
	{
		[Required]
		[MaxLength(50)]
		[MinLength(5)]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		[IgnoreDataMember]
		public string Email { get; set; }

		[Required]
		[IgnoreDataMember]
		public Password Password { get; set; }
	}
}