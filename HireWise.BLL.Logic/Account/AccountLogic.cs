using HireWise.BLL.Logic.Contracts.Account;
using HireWise.BLL.Logic.Contracts.Services;
using HireWise.Common.Entities.UserModels.InputModels;
using HireWise.DAL.Repository.Contracts;
using Microsoft.Extensions.Logging;

namespace HireWise.BLL.Logic.Account
{
    public class AccountLogic : IAccountLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ILogger<AccountLogic> _logger;

        public AccountLogic(
            IUserRepository userRepository,
            IPasswordService passwordService,
            ILogger<AccountLogic> logger)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _logger = logger;
        }

        public async Task ChangePasswordAsync(ChangePasswordModel model)
        {
            try
            {
                var user = _userRepository.GetAsync(model.Email).Result;

                if (user is null || !_passwordService.VerifyPassword(model.SecretWord, user.SecretWord))
                {
                    _logger.LogDebug("there is no user with email {model.email}", model.Email);
                    throw new ArgumentException("There is no user with this Email or Secret Word is incorrect");
                }

                user.Password = _passwordService.HashPassword(model.NewPassword);
                await _userRepository.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while changing the password");
                throw;
            }
        }

        public async Task BanAsync(Guid userToBanId, Guid bannersEmail)
        {
            try
            {
                var bannersUser = await _userRepository.GetAsync(bannersEmail);
                var userToBan = await _userRepository.GetAsync(userToBanId);

                if (bannersUser.UserGroup.Id == 2)
                {
                    await Ban(userToBan.Id);
                }

                if (bannersUser.UserGroupId > 1 && userToBan.UserGroupId == 1)
                {
                    await Ban(userToBan.Id);
                }
                else
                {
                    throw new ArgumentException("Insufficient rights to ban user");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while banning the user");
                throw;
            }

        }

        public async Task ChangeUserGroupAsync(Guid userId, int userGroupId)
        {
            try
            {
                var user = await _userRepository.GetAsync(userId);

                if (user is null || user.UserGroupId == 2 || userGroupId == 2)
                {
                    _logger.LogError("There is no user with Id: {user.Id} or wrong user", user.Id);
                    throw new ArgumentNullException("Wrong id or user");
                }

                user.UserGroupId = userGroupId;
                await _userRepository.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError("UpUserGroup error");
                throw;
            }
        }

        private async Task Ban(Guid userToBanId)
        {
            var user = await _userRepository.GetAsync(userToBanId);

            if (user is null)
            {
                _logger.LogError("There is no user with Id: {user.Id}", user.Id);
                throw new ArgumentException("Wrong Id");
            }

            user.IsBanned = true;
            _logger.LogInformation($"Banned {user.Id}");
            await _userRepository.UpdateAsync(user);
        }
    }
}
