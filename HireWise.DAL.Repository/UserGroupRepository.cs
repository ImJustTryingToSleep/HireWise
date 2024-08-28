using HireWise.Common.Entities.RoleModels.DB;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;
using HireWise.DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HireWise.DAL.Repository
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly HireWiseDBContext _dbContext;

        public UserGroupRepository(HireWiseDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        // добавление юзер группы                            ---OK
        // удаление юзер группы                              ---OK
        // изменение юзер группы
        // получение списка юзеров из конкретной юзер группы ---OK
        // Получение списка ролей из группы                  ---OK
        public async Task CreateAsync(UserGroup userGroup)
        {
            await _dbContext.UserGroups.AddAsync(userGroup);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserGroup> GetAsync(int id)
        {
            return await _dbContext.UserGroups.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            _dbContext.UserGroups.Remove(GetAsync(id).Result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetUsers(int id)
        {
            var users = _dbContext.Users.Where(u => u.UserGroupId == id);
            return users.ToList();
        }

        public async Task<List<Role>> GetRoles(int id) // Добавить связь между ролями и юзер группой
        {
            var userGroup = await GetAsync(id);
            return userGroup.Roles.ToList();
        }

        public async Task UpdateAsync(UserGroup userGroup)
        {
            var existingGroup = await GetAsync(userGroup.Id);

            if (existingGroup is null)
                throw new KeyNotFoundException($"UserGroup with ID {userGroup.Id} not found.");

            existingGroup.Name = userGroup.Name;
            
            if (userGroup.Roles is not null
                && !existingGroup.Roles.Equals(userGroup.Roles))
            {
                existingGroup.Roles.Clear();
                existingGroup.Roles.AddRange(userGroup.Roles);
            }
                

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Получение базовой группы для зарегистрированного пользователя.
        /// </summary>
        /// <returns>Базовая группа</returns>
        public async Task<UserGroup> GetDefaultGroupAsync() =>
            await _dbContext.UserGroups.FirstOrDefaultAsync(r => r.Name == "RegisteredUsers");        
    }
}
