using Domain.Helpers;

namespace CrossCuting.Extensions
{
    public class AuthExtensions
    {
        private AppSettings _appSettings;
        public AuthExtensions(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        public bool ValidatePassword(string Password, string PasswordHash, string PasswordSalt)
        {
            return PasswordHash.Equals(BCrypt.Net.BCrypt.HashPassword(Password, PasswordSalt));
        }
        public void GeneratePassword(string Password, out string PasswordSalt,out string PasswordHash)
        {
            PasswordSalt = BCrypt.Net.BCrypt.GenerateSalt(_appSettings.WorkFactor);
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password, PasswordSalt);
        }
    }
}
