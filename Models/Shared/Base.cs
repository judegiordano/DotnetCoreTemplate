using System.ComponentModel.DataAnnotations;

namespace WebApiTemplate.Models.Shared
{
    public class Base
    {
        [Key]
        public int Id { get; set; }    
    }    
}