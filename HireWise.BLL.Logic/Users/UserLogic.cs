using HireWise.BLL.Logic.Contracts.Users;
using HireWise.BLL.Logic.Services;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;
using HireWise.DAL.Repository.Contracts;
using Microsoft.Extensions.Logging;

namespace HireWise.BLL.Logic.Users
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserGroupRepository _userGroupRepository;
        private readonly PasswordService _passwordService;

        private readonly ILogger<UserLogic> _logger;

        public UserLogic(
            IUserRepository userRepository,
            IUserGroupRepository userGroupRepository,
            PasswordService passwordService,
            ILogger<UserLogic> logger)
        {
            _userRepository = userRepository;
            _userGroupRepository = userGroupRepository;
            _passwordService = passwordService;
            _logger = logger;
        }

        public async Task CreateUserAsync(UserCreateInputModel userInputModel)
        {
            try
            {
                var user = new User
                {
                    Login = userInputModel.Login!,
                    Email = userInputModel.Email!,
                    Password = _passwordService.HashPassword(userInputModel.Password!),
                    UserGroup = await _userGroupRepository.GetDefaultGroupAsync()
                };

                await _userRepository.CreateUserAsync(user);
                _logger.LogInformation("User was created");
            }
            catch (Exception)
            {
                _logger.LogError("An error occurred while creating the user");
                throw;
            }

        }

        public async Task<User?> GetAsync(string login) =>
            await _userRepository.GetAsync(login);
    }
}
