using WebApiTemplate.Dtos.Password;

namespace WebApiTemplate.Dtos.User
{
    public class UserDto : BaseDto
    {
        public string Username { get; set; }
        public PasswordDto Password { get; set; }
    }
}