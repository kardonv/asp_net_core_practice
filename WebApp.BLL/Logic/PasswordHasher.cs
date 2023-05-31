using System.Security.Cryptography;
using System.Text;
using WebApp.BLL.DTO;

namespace WebApp.BLL.Logic
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var sha1 = SHA1.Create();
            var hash = sha1.ComputeHash(bytes);

            return Encoding.UTF8.GetString(hash);
        }

        public static bool IsPasswordValid(UserDTO user, string password)
        {
            var passwordHash = HashPassword(password);

            return user.Password == passwordHash;
        }
    }
}
