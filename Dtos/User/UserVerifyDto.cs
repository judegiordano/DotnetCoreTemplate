using System.ComponentModel.DataAnnotations;
using WebApiTemplate.Dtos.Password;

namespace WebApiTemplate.Dtos.User
{
    public class UserVerifyDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public PasswordVerifyDto Password { get; set; }
    }
}