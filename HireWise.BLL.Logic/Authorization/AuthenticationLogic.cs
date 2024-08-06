using HireWise.BLL.Logic.Contracts.Authorization;
using HireWise.DAL.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
//using Microsoft.VisualStudio.Services.TestManagement.TestPlanning.WebApi;

namespace HireWise.BLL.Logic.Authorization
{
    public class AuthenticationLogic : IAuthenticationLogic
    {

        private readonly IUserRepository _userRepository;

        public AuthenticationLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IResult> GetJwtAsync(string login, string password)
        {
            // находим пользователя 
            var user = await _userRepository.GetAsync(login, password);
            // если пользователь не найден, отправляем статусный код 401
            if (user is null) return Results.Unauthorized();

            var claims = new List<Claim> { new Claim( ClaimTypes.Name, user.Login) };
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

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
