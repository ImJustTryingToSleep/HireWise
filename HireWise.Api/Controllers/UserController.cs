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

        [HttpGet("{id}")]
        public async Task<User> GetAsync(Guid Id)
        {
            return await _userLogic.GetAsync(Id);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<List<User>> GetAsync()
        {
            return await _userLogic.GetAsync();
        }


        [HttpPost]
        [Route("Registration")]
        public async Task PostAsync([FromBody] UserInputModel user)
        {
            await _userLogic.CreateUserAsync(user);
        }

        
        [HttpPut]
        [Route("update")]
        public async Task Put([FromBody] UserInputModel userInputModel, Guid id)
        {
            await _userLogic.UpdateAsync(userInputModel, id);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task DeleteAsync(Guid id)
        {
            await _userLogic.DeleteAsync(id);
        }
    }
}
