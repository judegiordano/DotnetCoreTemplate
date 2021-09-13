using System.ComponentModel.DataAnnotations;
using WebApiTemplate.Models.Shared;

namespace WebApiTemplate.Models
{
    public class User : Base
    {
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Username { get; set; }
        [Required]
        public Password Password { get; set; }
    }
}