using HireWise.Common.Entities.UserModels.DB;

namespace HireWise.DAL.Repository.Contracts
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task<User?> GetAsync(string login);
        Task<User?> GetAsync(Guid id);
        Task<List<User>> GetAsync();
        Task DeleteAsync(Guid id);
        Task UpdateAsync(User user);
    }
}
