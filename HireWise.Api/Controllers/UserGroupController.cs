using HireWise.BLL.Logic.Contracts.UserGroup;
using HireWise.Common.Entities.RoleModels.DB;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HireWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly IUserGroupLogic _userGroupLogic;

        public UserGroupController(IUserGroupLogic userGroupLogic)
        {
            _userGroupLogic = userGroupLogic;
        }

        // GET api/<UserGroupController>/5
        [HttpGet]
        [Route("getUsers")]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<User>> GetUsersAsync(int id)
        {
            var users = await _userGroupLogic.GetUsers(id);
            return users;
        }

        [HttpGet]
        [Route("getRoles")]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<Role>> GetRolesAsync(int id)
        {
            return await _userGroupLogic.GetRoles(id);
        }

        // POST api/<UserGroupController>
        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Root")]
        public async Task PostAsync([FromBody] UserGroupInputModel inputModel)
        {
            await _userGroupLogic.CreateAsync(inputModel);
        }

        [HttpPost]
        [Route("update")]
        [Authorize(Roles = "Root")]
        public async Task UpdateAsync(int id, [FromBody] UserGroupInputModel inputModel)
        {
            await _userGroupLogic.UpdateAsync(id, inputModel);
        }

        [HttpPost]
        [Route("change_roles")]
        [Authorize(Roles = "Root")]
        public async Task UpdateAsync(int id, [FromBody] IEnumerable<int> roleIds)
        {
            await _userGroupLogic.ChangeRoles(id, roleIds);
        }

        // DELETE api/<UserGroupController>/5
        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = "Root")]
        public async Task DeleteAsync(int id)
        {
            await _userGroupLogic.DeleteAsync(id);
        }
    }
}
