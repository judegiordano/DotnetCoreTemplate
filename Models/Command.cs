using System.ComponentModel.DataAnnotations;
using WebApiTemplate.Models.Shared;

namespace WebApiTemplate.Models
{
    public class Command : Base
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}