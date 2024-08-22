using HireWise.BLL.Logic.Contracts.UserGroup;
using HireWise.BLL.Logic.UserGroupLogic;
using HireWise.Common.Entities.RoleModels.DB;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;
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


        //// GET: api/<UserGroupController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<UserGroupController>/5
        [HttpGet]
        [Route("getUsers")]
        public async Task<List<User>> GetUsersAsync(int id)
        {
            var users = await _userGroupLogic.GetUsers(id);
            return users;
        }

        [HttpGet]
        [Route("getRoles")]
        public async Task<List<Role>> GetRolesAsync(int id)
        {
            return await _userGroupLogic.GetRoles(id);
        }

        // POST api/<UserGroupController>
        [HttpPost]
        [Route("create")]
        public async Task PostAsync([FromBody] UserGroupInputModel inputModel)
        {
            await _userGroupLogic.CreateAsync(inputModel);
        }

        // PUT api/<UserGroupController>/5
        [HttpPut]
        [Route("update")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserGroupController>/5
        [HttpDelete]
        [Route("delete")]
        public async Task DeleteAsync(int id)
        {
            await _userGroupLogic.DeleteAsync(id);
        }
    }
}
