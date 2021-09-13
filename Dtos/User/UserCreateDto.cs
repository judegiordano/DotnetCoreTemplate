using System.ComponentModel.DataAnnotations;
using WebApiTemplate.Dtos.Password;

namespace WebApiTemplate.Dtos.User
{
    public class UserCreateDto
    {
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Username { get; set; }
        [Required]
        public PasswordCreateDto Password { get; set; }
    }
}