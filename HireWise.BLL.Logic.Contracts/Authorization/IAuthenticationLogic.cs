﻿using HireWise.Common.Entities.UserModels.InputModels;
using Microsoft.AspNetCore.Http;

namespace HireWise.BLL.Logic.Contracts.Authorization
{
    public interface IAuthenticationLogic
    {
        Task<IResult> GetJwtAsync(string login, string password);
        Task<IResult> GetJwtAsync(UserInputModel inputModel);
    }
}
