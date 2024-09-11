using HireWise.Common.Entities.RoleModels.DB;
using HireWise.Common.Entities.UserModels.DB;
using System.Threading.Tasks;

namespace HireWise.DAL.Repository.Contracts
{
    public interface IUserGroupRepository
    {
        Task<UserGroup> GetDefaultGroupAsync();
        Task CreateAsync(UserGroup userGroup);
        Task DeleteAsync(int id);
        Task<List<User>> GetUsers(int id);
        Task<List<Role>> GetRoles(int id);
    }
}
