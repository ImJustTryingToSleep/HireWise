using HireWise.BLL.Logic.Contracts.Authorization;
using HireWise.BLL.Logic.Contracts.Services;
using HireWise.BLL.Logic.Services;
using HireWise.Common.Entities.UserModels.InputModels;
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
        private readonly IPasswordService _passwordService;

        private readonly ILogger<AuthenticationLogic> _logger;

        public AuthenticationLogic(IUserRepository userRepository, 
            AuthOptions authOptions,
            IPasswordService passwordService,
            ILogger<AuthenticationLogic> logger)
        {
            _userRepository = userRepository;
            _authOptions = authOptions;
            _passwordService = passwordService;
            _logger = logger;
        }
        public async Task<IResult> GetJwtAsync(UserInputModel inputModel)
        {
            if (inputModel == null || string.IsNullOrEmpty(inputModel.Email) || string.IsNullOrEmpty(inputModel.Password))
            {
                var errorText = "Login and password must be provided.";
                _logger.LogError(errorText);
                return Results.Unauthorized();
            }
            return await GetJwtAsync(inputModel.Email, inputModel.Password);
        }
        public async Task<IResult> GetJwtAsync(string email, string password)
        {
            // находим пользователя 
            var user = await _userRepository.GetAsync(email);
            // если пользователь не найден, отправляем статусный код 401
            if (user is null 
                || !_passwordService.VerifyPassword(password, user.Password)) 
                return Results.Unauthorized();

            if(user.IsBanned)
            {
                throw new Exception("User is banned");
            }

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
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
            _logger.LogInformation($"Generated token for user: {email}");

            // формируем ответ
            var response = new
            {
                access_token = encodedJwt,
                username = user.Email
            };

            return Results.Json(response);
        }
    }
}
