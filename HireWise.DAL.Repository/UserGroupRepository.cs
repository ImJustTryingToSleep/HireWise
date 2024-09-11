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

        public async Task<List<Role>> GetRoles(int id)             // Добавить связь между ролями и юзер группой
        {
            var userGroup = GetAsync(id).Result;
            return userGroup.Roles.ToList();
        }

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
