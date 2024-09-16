using HireWise.Common.Entities.UserModels.InputModels;

namespace HireWise.BLL.Logic.Contracts.Account
{
    public interface IAccountLogic
    {
        Task ChangePasswordAsync(ChangePasswordModel model);
        Task BanAsync(Guid userToBanId, Guid bannersId);
        Task ChangeUserGroupAsync(Guid id, int userGroupId);
    }
}
