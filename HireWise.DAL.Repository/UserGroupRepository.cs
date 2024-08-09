using HireWise.Common.Entities.RoleModels.DB;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.DAL.Repository
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly DBContext _dbContext;

        public UserGroupRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        // добавление юзер группы
        // удаление юзер группы
        // изменение юзер группы
        // получение списка юзеров из конкретной юзер группы
        // Получение списка ролей из группы

        /// <summary>
        /// Получение дефолтной юзер группы
        /// </summary>
        /// <returns>Дефолтная юзер группа</returns>
        public async Task<UserGroup> GetDefaultGroupAsync()
        {
            //DefaultCreateUserGroup();
            List<UserGroup>? userGroup = await _dbContext.UserGroups.ToListAsync();
            if (userGroup == null || userGroup.Count == 0)
            {
                DefaultCreateUserGroup();
            }
            return userGroup.FirstOrDefault(r => r.Name == "RegisteredUser");
        }

        private async Task DefaultCreateUserGroup()
        {
            var role = new Role { Id = 1, Name = "Read" };
            _dbContext.Roles.Add(role);

            var userGroup = new UserGroup { Id = 1, Name = "RegisteredUser" };
            _dbContext.UserGroups.Add(userGroup);
            
            role.UserGroups.Add(userGroup);
            userGroup.Roles.Add(role);

            await _dbContext.SaveChangesAsync();

        }
    }
}
