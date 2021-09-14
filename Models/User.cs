using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Models.Shared;

namespace WebApiTemplate.Models
{
    [Index(nameof(Username), IsUnique = true)]
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