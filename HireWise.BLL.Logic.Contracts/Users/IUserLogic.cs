using HireWise.Common.Entities.QuestionModels.InputModels;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;

namespace HireWise.BLL.Logic.Contracts.Users
{
    public interface IUserLogic
    {
        Task CreateUserAsync(UserInputModel userInputModel);
        Task<User?> GetAsync(string login);
        Task<User> GetByIdAsync(Guid id);
    }
}
