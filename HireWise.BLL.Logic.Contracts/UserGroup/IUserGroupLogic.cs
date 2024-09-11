using HireWise.Common.Entities.RoleModels.DB;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;

namespace HireWise.BLL.Logic.Contracts.UserGroup
{
    public interface IUserGroupLogic
    {
        Task CreateAsync(UserGroupInputModel inputModel);
        Task DeleteAsync(int id);
        Task<List<User>> GetUsers(int id);
        Task<List<Role>> GetRoles(int id);
    }
}
