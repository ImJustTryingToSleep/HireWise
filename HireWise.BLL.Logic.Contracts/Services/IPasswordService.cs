namespace HireWise.BLL.Logic.Contracts.Services
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string passwordToCheck);
    }
}