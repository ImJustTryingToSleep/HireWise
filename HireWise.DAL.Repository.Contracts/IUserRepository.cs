using HireWise.Common.Entities.UserModels.DB;

namespace HireWise.DAL.Repository.Contracts
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);

        Task<User?> GetAsync(string login, string password);
    }
}
