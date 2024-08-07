using HireWise.BLL.Logic.Contracts.Authorization;
using HireWise.Common.Entities.UserModels.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HireWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILogger<AuthorizationController> _logger;
        private readonly IAuthenticationLogic _authorizationLogic;

        public AuthorizationController(IAuthenticationLogic authorizationLogic, ILogger<AuthorizationController> logger)
        {
            _authorizationLogic = authorizationLogic;
            _logger = logger;
        }

        // GET api/<AuthorizationController>/
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(new { value = "Well done, Turner!" });
        }

        // POST api/<AuthorizationController>/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserCreateInputModel request)
        {
            if (request == null || string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Password))
            {
                var errorText = "Login and password must be provided.";
                _logger.LogError(errorText);
                return BadRequest(errorText);
            }

            var token = await _authorizationLogic.GetJwtAsync(request.Login, request.Password);
            _logger.LogInformation($"Generated token for user: {request.Login}");
            return Ok(token);
        }


        // POST api/<AuthorizationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthorizationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthorizationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
