using HireWise.BLL.Logic.Contracts.Authorization;
using HireWise.BLL.Logic.Services;
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

        public async Task<IResult> GetJwtAsync(string login, string password)
        {
            // находим пользователя 
            var user = await _userRepository.GetAsync(login);
            // если пользователь не найден, отправляем статусный код 401
            if (user is null 
                || !_passwordService.VerifyPassword(password, user.Password)) 
                return Results.Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var role in user.UserGroup.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
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
            _logger.LogInformation($"Generated token for user: {login}");

            // формируем ответ
            var response = new
            {
                access_token = encodedJwt,
                username = user.Login
            };

            return Results.Json(response);
        }
    }
}
