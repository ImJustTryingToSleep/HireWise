using HireWise.Common.Entities.RoleModels.DB;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;

namespace HireWise.BLL.Logic.Contracts.UserGroup
{
    public interface IUserGroupLogic
    {
        Task CreateAsync(UserGroupInputModel inputModel);
        Task UpdateAsync(int id, UserGroupInputModel inputModel);
        Task ChangeRoles(int id, IEnumerable<int> roleIds);
        Task DeleteAsync(int id);
        Task<IEnumerable<User>> GetUsers(int id);
        Task<IEnumerable<Role>> GetRoles(int id);
    }
}
