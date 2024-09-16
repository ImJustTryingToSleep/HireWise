using HireWise.Common.Entities.RoleModels.DB;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;
using System.Threading.Tasks;

namespace HireWise.DAL.Repository.Contracts
{
    public interface IUserGroupRepository
    {
        Task<UserGroup> GetAsync(int id);
        Task<UserGroup> GetDefaultGroupAsync();
        Task CreateAsync(UserGroup userGroup);
        Task UpdateAsync(UserGroup inputModel);
        Task DeleteAsync(int id);
        Task<IEnumerable<User>> GetUsers(int id);
        Task<IEnumerable<Role>> GetRoles(int id);
        Task<Role> GetRoleById(int id);
    }
}
