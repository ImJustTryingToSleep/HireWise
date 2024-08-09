using HireWise.Common.Entities.UserModels.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.DAL.Repository.Contracts
{
    public interface IUserGroupRepository
    {
        Task<UserGroup> GetDefaultGroupAsync();
    }
}
