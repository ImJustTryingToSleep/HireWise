using HireWise.BLL.Logic.Contracts.Authorization;

namespace HireWise.Api.GraphQL
{
    public class Mutations
    {
        private readonly IAuthenticationLogic _authorizationLogic;
        private readonly ILogger<Mutations> _logger;

        public Mutations(IAuthenticationLogic authorizationLogic, ILogger<Mutations> logger)
        {
            _authorizationLogic = authorizationLogic;
            _logger = logger;
        }

        [GraphQLName("login")]
        public async Task<string> LoginAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                var errorText = "Login and password must be provided.";
                _logger.LogError(errorText);
                throw new GraphQLException(errorText);
            }

            var user = 

            return await _authorizationLogic.GetJwtAsync(username, password);
        }
    }
}
