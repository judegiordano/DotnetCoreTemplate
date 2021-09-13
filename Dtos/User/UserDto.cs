using WebApiTemplate.Dtos.Password;
using WebApiTemplate.Models.Shared;

namespace WebApiTemplate.Dtos.User
{
    public class UserDto : Base
    {
        public string Username { get; set; }
        public PasswordDto Password { get; set; }
    }
}