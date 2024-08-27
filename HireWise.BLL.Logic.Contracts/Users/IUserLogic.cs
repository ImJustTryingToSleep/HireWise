using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;

namespace HireWise.BLL.Logic.Contracts.Users
{
    public interface IUserLogic
    {
        Task CreateAsync(UserInputModel userInputModel);
        Task<User?> GetAsync(string login);
        Task<User> GetAsync(Guid id);
        IAsyncEnumerable<User> GetAsync();
        Task UpdateAsync(UserInputModel userInputModel, Guid id);
        Task DeleteAsync(Guid id);
        Task BanAsync(Guid id);
    }
}
