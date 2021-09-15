using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Services.Utility;

namespace WebApiTemplate.Models.Shared
{
    [Index(nameof(Uid), IsUnique = true)]
    public class Base
    {
        public Base() => Uid = Utility.GenerateGuid();
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid Uid { get; private set; }
    }
}