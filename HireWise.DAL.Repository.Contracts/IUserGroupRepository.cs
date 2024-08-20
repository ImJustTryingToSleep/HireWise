using HireWise.Common.Entities.UserModels.DB;

namespace HireWise.DAL.Repository.Contracts
{
    public interface IUserGroupRepository
    {
        Task<UserGroup> GetDefaultGroupAsync();
    }
}
