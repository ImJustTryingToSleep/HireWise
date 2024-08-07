using HireWise.BLL.Logic.Contracts.Users;
using HireWise.Common.Entities.Enums;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;
using HireWise.DAL.Repository;
using HireWise.DAL.Repository.Contracts;
using Microsoft.Extensions.Logging;

namespace HireWise.BLL.Logic.Users
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;

        private readonly ILogger<UserLogic> _logger;

        public UserLogic(
            IUserRepository userRepository,
            ILogger<UserLogic> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task CreateUserAsync(UserCreateInputModel userInputModel)
        {
            try
            {
                var user = new User
                {
                    Login = userInputModel.Login,
                    Email = userInputModel.Email,
                    Password = userInputModel.Password
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

        public async Task<User?> GetAsync(string login, string password)
        {
            var user = await _userRepository.GetAsync(login, password);
            return user;
        }
    }
}
