using HireWise.Common.Entities.RoleModels.DB;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;

namespace HireWise.BLL.Logic.Contracts.Users
{
    public interface IUserLogic
    {
        Task CreateUserAsync(UserCreateInputModel userInputModel);

        Task<User?> GetAsync(string login);

        Task<IEnumerable<Role>?> GetRolesAsync(User user);
    }
}
