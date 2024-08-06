using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.BLL.Logic.Contracts.Users
{
    public interface IUserLogic
    {
        Task CreateUserAsync(UserCreateInputModel userInputModel);

        Task<User> GetAsync(string login, string password);
    }
}
