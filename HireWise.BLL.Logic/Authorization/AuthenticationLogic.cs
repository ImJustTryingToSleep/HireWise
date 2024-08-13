using HireWise.BLL.Logic.Contracts.Authorization;
using HireWise.BLL.Logic.Services;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.DAL.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HireWise.BLL.Logic.Authorization
{
    public class AuthenticationLogic : IAuthenticationLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthOptions _authOptions;
        private readonly PasswordService _passwordService;

        private readonly ILogger<AuthenticationLogic> _logger;

        public AuthenticationLogic(IUserRepository userRepository,
            AuthOptions authOptions,
            PasswordService passwordService,
            ILogger<AuthenticationLogic> logger)
        {
            _userRepository = userRepository;
            _authOptions = authOptions;
            _passwordService = passwordService;
            _logger = logger;
        }

        /// <summary>
        /// Получить токен по логину и паролю
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns>Токен или null в случае ошибки</returns>
        public async Task<string?> GetJwtAsync(string username, string password)
        {
            var user = await _userRepository.GetAsync(username);

            // если пользователь не найден или пароль неверный
            if (user is null || !_passwordService.VerifyPassword(password, user.Password))
            {
                _logger.LogError($"Invalid login attempt for user {username}.");
                return null;
            }

            return await GenerateJwtAsync(user);
        }

        public async Task<string?> GetJwtAsync(User user) =>
            await GenerateJwtAsync(user);

        /// <summary>
        /// Получить токен для указанного пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Токен</returns>
        private async Task<string> GenerateJwtAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            // Добавляем роли, если они есть
            if (user.UserGroup.Roles != null)
            {
                foreach (var role in user.UserGroup.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }
            }

            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                issuer: _authOptions.Issuer,
                audience: _authOptions.Audience,
                claims: claims,
                expires: DateTime.Now.Add(TimeSpan.FromMinutes(_authOptions.ExpiryMinutes)),
                signingCredentials: new SigningCredentials(_authOptions.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            _logger.LogInformation($"Generated token for user: {user.Login}");

            return encodedJwt;
        }

    }
}
