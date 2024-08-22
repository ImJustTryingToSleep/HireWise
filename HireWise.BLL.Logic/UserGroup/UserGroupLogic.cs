using AutoMapper;
using HireWise.BLL.Logic.Contracts.UserGroup;
using HireWise.Common.Entities.RoleModels.DB;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;
using HireWise.DAL.Repository;
using HireWise.DAL.Repository.Contracts;
using Microsoft.Extensions.Logging;

namespace HireWise.BLL.Logic.UserGroupLogic
{
    public class UserGroupLogic : Contracts.UserGroup.IUserGroupLogic
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

        public async Task DeleteAsync(int id)
        {
            await _userGroupRepository.DeleteAsync(id);
        }

        public async Task<List<User>> GetUsers(int id)
        {
            var users = await _userGroupRepository.GetUsers(id);
            return users;
        }

        public async Task<List<Role>> GetRoles(int id)
        {
            return await _userGroupRepository.GetRoles(id);
        }

    }
}
