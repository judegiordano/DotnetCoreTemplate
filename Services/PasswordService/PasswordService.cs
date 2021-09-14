using BC = BCrypt.Net.BCrypt;

namespace WebApiTemplate.Services.PasswordService
{
    public class PasswordService
    {
        public static string HashPassword(string password)
        {
            return BC.HashPassword(password);
        }

        public static bool VerifyHash(string password, string hash)
        {
            return BC.Verify(password, hash);
        }
    }
}