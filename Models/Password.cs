using System.ComponentModel.DataAnnotations;
using WebApiTemplate.Models.Shared;

namespace WebApiTemplate.Models
{
	public class Password : Base
	{
		[Required]
		public string Hash { get; set; }
		public int LoginAttempts { get; set; } = 0;
	}
}