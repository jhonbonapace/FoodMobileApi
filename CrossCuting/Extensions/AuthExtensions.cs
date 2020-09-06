using Domain.Helpers;
using System.Security.Cryptography;
using System.Text;

namespace CrossCuting.Extensions
{
    public class AuthExtensions
    {
        private AppSettings _appSettings;
        public AuthExtensions(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        public bool ValidatePassword(string Password, string PasswordHash)
        {
            return BCrypt.Net.BCrypt.Verify(Password, PasswordHash);
        }
        public void GeneratePassword(string Password, out string PasswordSalt,out string PasswordHash)
        {
            PasswordSalt = BCrypt.Net.BCrypt.GenerateSalt(_appSettings.WorkFactor);

            PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password, PasswordSalt);
        }
        public static string GenerateRecoveryHash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                var sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }     
        }
    }
}
