using HireWise.BLL.Logic.Authorization;
using HireWise.BLL.Logic.Contracts.Authorization;
using HireWise.BLL.Logic.Contracts.Users;
using HireWise.BLL.Logic.Users;
using HireWise.DAL.Repository;
using HireWise.DAL.Repository.Contracts;

namespace HireWise.Api.Extensions
{
    public static class DIExtensions
    {
        public static IServiceCollection ConfigureBLLDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IAuthenticationLogic, AuthenticationLogic>();
            return services;
        }

        public static IServiceCollection ConfigureDALDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
