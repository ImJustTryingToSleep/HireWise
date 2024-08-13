using HireWise.BLL.Logic.Authorization;
using HireWise.BLL.Logic.Contracts.Authorization;
using HireWise.BLL.Logic.Contracts.Services;
using HireWise.BLL.Logic.Contracts.Users;
using HireWise.BLL.Logic.Services;
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
            services.AddScoped<IUserGroupRepository, UserGroupRepository>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddSingleton<PasswordHasher>();
            return services;
        }

        public static IServiceCollection ConfigureDALDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
