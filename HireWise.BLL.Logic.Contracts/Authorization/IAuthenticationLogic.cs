using Microsoft.AspNetCore.Http;

namespace HireWise.BLL.Logic.Contracts.Authorization
{
    public interface IAuthenticationLogic
    {
        Task<IResult> GetJwtAsync(string login, string password);
    }
}
