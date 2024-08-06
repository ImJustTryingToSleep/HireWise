using HireWise.BLL.Logic.Contracts.Authorization;
using HireWise.Common.Entities.UserModels.DB;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HireWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationLogic _authorizationLogic;

        public AuthorizationController(IAuthorizationLogic authorizationLogic)
        {
            _authorizationLogic = authorizationLogic;
        }

        // GET: api/<AuthorizationonController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthorizationonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/<UserController>/5
        [HttpGet("{login}, {password}")]
        public async Task<IResult> AuthorizationAsync(string login, string password)
        {
            return await _authorizationLogic.GetJwtAsync(login, password);
        }

        // POST api/<AuthorizationonController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthorizationonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthorizationonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
