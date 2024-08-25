using HireWise.BLL.Logic.Contracts.Services;

namespace HireWise.BLL.Logic.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher _passwordHasher;

        public PasswordService(PasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(password);
        }

        public bool VerifyPassword(string hashedPassword, string passwordToCheck)
        {
            return _passwordHasher.VerifyPassword(hashedPassword, passwordToCheck);
        }
    }
}
