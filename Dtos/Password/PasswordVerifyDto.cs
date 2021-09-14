using System.ComponentModel.DataAnnotations;

namespace WebApiTemplate.Dtos.Password
{
    public class PasswordVerifyDto
    {
        [Required]
        public string Hash { get; set; }
    }
}