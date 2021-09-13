using System.ComponentModel.DataAnnotations;

namespace WebApiTemplate.Dtos.Password
{
    public class PasswordCreateDto
    {
        [Required]
        public string Hash { get; set; }
    }
}