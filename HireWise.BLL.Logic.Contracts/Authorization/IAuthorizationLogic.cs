using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.BLL.Logic.Contracts.Authorization
{
    public interface IAuthorizationLogic
    {
        Task<IResult> GetJwtAsync(string login, string password);
    }
}
