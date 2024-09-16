using AutoMapper;
using HireWise.BLL.Logic.Contracts.UserGroup;
using HireWise.Common.Entities.QuestionModels.InputModels;
using HireWise.Common.Entities.RoleModels.DB;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;
using HireWise.DAL.Repository.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace HireWise.BLL.Logic.UserGroupLogic
{
    public class UserGroupLogic : IUserGroupLogic
    {
        private readonly IUserGroupRepository _userGroupRepository;
        private readonly ILogger<UserGroupLogic> _logger;
        private readonly IMapper _mapper;

        public UserGroupLogic(
            IUserGroupRepository userGroupRepository,
            ILogger<UserGroupLogic> logger,
            IMapper mapper)
        {
            _userGroupRepository = userGroupRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateAsync(UserGroupInputModel inputModel)
        {
            try
            {
                var userGroup = _mapper.Map<UserGroup>(inputModel);

                await _userGroupRepository.CreateAsync(userGroup);
                _logger.LogInformation("UserGroup was created with Id: {userGroup.Id}", userGroup.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the UserGroup");
            }
        }

        public async Task UpdateAsync(int id, UserGroupInputModel inputModel)
        {
            var userGroup = await _userGroupRepository.GetAsync(id);

            if (userGroup is null)
            {
                _logger.LogError($"There is no record with Id: {id}");
                throw new NullReferenceException("userGroup is null");
            }

            _mapper.Map(inputModel, userGroup);

            await _userGroupRepository.UpdateAsync(userGroup);
        }

        public async Task ChangeRoles(int id, IEnumerable<int> roleIds)
        {
            var userGroup = await _userGroupRepository.GetAsync(id);

            if (userGroup == null)
            {
                throw new ArgumentException("User group not found");
            }

            var roleIdSet = new HashSet<int>(roleIds); // Используем HashSet для оптимизации поиска            
            var missingRoles = new List<Role>(); // Список для хранения отсутствующих ролей            
            var newRoles = new List<Role>(); // Получаем новые роли асинхронно

            foreach (var roleId in roleIds)
            {
                var role = await _userGroupRepository.GetRoleById(roleId);
                if (role != null) // Проверяем, что роль не null
                {
                    newRoles.Add(role);
                }
            }
            
            userGroup.Roles.Clear(); // Обновляем роли в userGroup
            userGroup.Roles.AddRange(newRoles);

            await _userGroupRepository.UpdateAsync(userGroup);
        }

        public async Task DeleteAsync(int id)
        {
            await _userGroupRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsers(int id)
        {
            var users = await _userGroupRepository.GetUsers(id);
            return users;
        }

        public async Task<IEnumerable<Role>> GetRoles(int id)
        {
            return await _userGroupRepository.GetRoles(id);
        }

    }
}
