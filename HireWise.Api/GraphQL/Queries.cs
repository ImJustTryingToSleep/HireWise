using HireWise.BLL.Logic.Contracts.Authorization;
using HireWise.BLL.Logic.Contracts.Services;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.DAL.Repository;

namespace HireWise.Api.GraphQL
{
    public class Queries
    {
        private readonly IAuthenticationLogic _authorizationLogic;
        private readonly IPasswordService _passwordService;

        private readonly ILogger<Mutations> _logger;

        public Queries(IAuthenticationLogic authorizationLogic,
            IPasswordService passwordService,
            ILogger<Mutations> logger)
        {
            _authorizationLogic = authorizationLogic;
            _passwordService = passwordService;
            _logger = logger;
        }

        [UseProjection]
        public IQueryable<User> Read([Service] DBContext context) =>
            context.Users;

        [GraphQLName("login")]
        public async Task<string?> LoginAsync([Service] DBContext context, string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                var errorText = "Login and password must be provided.";
                _logger.LogError(errorText);
                throw new GraphQLException(errorText);
            }

            var user = context.Users.FirstOrDefault(u => u.Login == username);
            // если пользователь не найден или пароль неверный
            if (user is null || !_passwordService.VerifyPassword(password, user.Password))
            {
                _logger.LogError($"Invalid login attempt for user {username}.");
                return null;
            }

            return await _authorizationLogic.GetJwtAsync(user);
        }
    }
}
