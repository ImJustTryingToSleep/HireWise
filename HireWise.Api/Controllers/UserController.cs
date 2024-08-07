using HireWise.BLL.Logic.Contracts.Users;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.Common.Entities.UserModels.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<UserController>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(new { value = "Well done, Turner!" });
        }



        // POST api/<UserController>/Registration
        [HttpPost]
        [Route("Registration")]
        public async Task Post([FromBody] UserCreateInputModel user)
        {
            await _userLogic.CreateUserAsync(user);
        }

        // PUT api/<UserController>/5
        
        [HttpGet("{Authorize}")] 
        public void Put()
        {
            
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
