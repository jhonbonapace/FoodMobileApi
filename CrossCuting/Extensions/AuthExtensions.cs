using Domain.Entities;
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
        public bool ValidatePassword(User user)
        {
            return user.PasswordHash.Equals(BCrypt.Net.BCrypt.HashPassword(user.Password, user.PasswordSalt));
        }

        public void GeneratePassword(ref User user)
        {
            user.WorkFactor = _appSettings.WorkFactor;

            user.PasswordSalt = BCrypt.Net.BCrypt.GenerateSalt(user.WorkFactor);

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password, user.PasswordSalt);
        }
    }
}
