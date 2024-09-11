using HireWise.BLL.Logic.Contracts.Users;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HireWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpGet]
        [Route("getById")]
        public async Task<User> GetAsync(Guid Id)
        {
            return await _userLogic.GetAsync(Id);
        }

        [HttpGet]
        [Route("getAll")]
        public IAsyncEnumerable<User> GetAsync()
        {
            return _userLogic.GetAsync();
        }


        [HttpPost]
        [Route("Registration")]
        public async Task PostAsync([FromBody] UserInputModel user)
        {
            await _userLogic.CreateAsync(user);
        }

        [HttpPost]
        [Route("ChangePassword")]
        [AllowAnonymous]
        public async Task ChangePassword(ChangePasswordModel model)
        {
            await _userLogic.ChangePasswordAsync(model);
        }


        [HttpPut]
        [Route("update")]
        public async Task Put([FromBody] UserInputModel userInputModel, Guid id)
        {
            await _userLogic.UpdateAsync(userInputModel);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task DeleteAsync(Guid id)
        {
            await _userLogic.DeleteAsync(id);
        }

        [HttpPost]
        [Route("ban")]
        public async Task BanAsync(Guid id)
        {
            await _userLogic.BanAsync(id);
        }
    }
}
