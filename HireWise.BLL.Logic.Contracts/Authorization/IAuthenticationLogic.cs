using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.BLL.Logic.Contracts.Authorization
{
    public interface IAuthenticationLogic
    {
        Task<IResult> GetJwtAsync(string login, string password);
    }
}
