using WebApiTemplate.Models.Shared;

namespace WebApiTemplate.Dtos.Password
{
    public class PasswordDto : Base
    {
        public int LoginAttempts { get; set; }
    }
}