using HireWise.BLL.Logic.Contracts.Account;
using HireWise.Common.Entities.UserModels.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HireWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountLogic _accountLogic;

        public AccountController(IAccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        [HttpPost]
        [Route("ChangePassword")]
        [AllowAnonymous]
        public async Task ChangePassword(ChangePasswordModel model)
        {
            await _accountLogic.ChangePasswordAsync(model);
        }

        [HttpPost]
        [Route("ban")]
        //[Authorize(Roles = "Admin")]
        public async Task BanAsync([FromBody] Guid userToBanId, Guid bannersId)
        {
            await _accountLogic.BanAsync(userToBanId, bannersId);
        }

        [HttpPost]
        [Route("upUserGroup")]
        [Authorize(Roles = "Root")]
        public async Task UpUserGroupAsync([FromBody] Guid id, int userGroupId)
        {
            await _accountLogic.ChangeUserGroupAsync(id, userGroupId);
        }
    }
}
