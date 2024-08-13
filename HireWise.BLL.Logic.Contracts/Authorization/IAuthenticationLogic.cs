using HireWise.Common.Entities.UserModels.DB;
using Microsoft.AspNetCore.Http;

namespace HireWise.BLL.Logic.Contracts.Authorization
{
    public interface IAuthenticationLogic
    {
        Task<string?> GetJwtAsync(string username, string password);
        Task<string?> GetJwtAsync(User user);
    }
}