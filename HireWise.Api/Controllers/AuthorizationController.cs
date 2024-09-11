using HireWise.BLL.Logic.Contracts.Authorization;
using HireWise.Common.Entities.UserModels.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HireWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILogger<AuthorizationController> _logger;
        private readonly IAuthenticationLogic _authorizationLogic;

        public AuthorizationController(
            IAuthenticationLogic authorizationLogic, 
            ILogger<AuthorizationController> logger)
        {
            _authorizationLogic = authorizationLogic;
            _logger = logger;
        }

        // POST api/<AuthorizationController>/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserInputModel request) => 
            Ok(await _authorizationLogic.GetJwtAsync(request));
    }
}