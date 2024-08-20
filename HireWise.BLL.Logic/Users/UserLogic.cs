using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly ILogger<UserLogic> _logger;

        private readonly PasswordService _passwordService;


        public UserLogic(
            IUserRepository userRepository,
            IUserGroupRepository userGroupRepository,
            IMapper mapper,
            ILogger<UserLogic> logger,
            PasswordService passwordService
            )
        {
            _userRepository = userRepository;
            _userGroupRepository = userGroupRepository;
            _mapper = mapper;
            _passwordService = passwordService;
            _logger = logger;
        }

        public async Task CreateUserAsync(UserInputModel userInputModel)
        {
            try
            {
                userInputModel.Password = _passwordService.HashPassword(userInputModel.Password!);
                var user = _mapper.Map<User>(userInputModel);
                user.UserGroup = await _userGroupRepository.GetDefaultGroupAsync();

                await _userRepository.CreateAsync(user);
                _logger.LogInformation("User was created");
            }
            catch (Exception)
            {
                _logger.LogError("An error occurred while creating the user");
                throw;
            }

        }

        public async Task<User?> GetAsync(string login) =>
            await _userRepository.GetAsync(login);//?

        public async Task<User?> GetAsync(Guid id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<List<User>> GetAsync()
        {
            return await _userRepository.GetAsync();
        }

        public async Task UpdateAsync(UserInputModel userInputModel, Guid id)
        {
            try
            {
                var user = GetAsync(id).Result;

                if (user != null)
                {
                    _mapper.Map(userInputModel, user);

                    await _userRepository.UpdateAsync(user);
                    _logger.LogInformation("User with Id: {question.Id} was updated", user.Id);
                }
                else
                {
                    _logger.LogError("There is no user with this Id: {id}", id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the user");
            }

        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task BanAsync(Guid id)
        {
            try
            {
                var user = await _userRepository.GetAsync(id);

                if (user != null)
                {
                    user.IsBanned = true;
                    _logger.LogInformation($"Banned {user.Id}");
                }
                else
                {
                    _logger.LogError("There is no user with Id: {user.Id}", user.Id);
                }

                await _userRepository.UpdateAsync(user);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while banning the user");
            }
            
        }

    }
}
