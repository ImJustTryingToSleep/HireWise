using HireWise.BLL.Logic.Authorization;
using HireWise.BLL.Logic.Contracts.Authorization;
using HireWise.BLL.Logic.Contracts.GradeLevels;
using HireWise.BLL.Logic.Contracts.ITechTransferLogic;
using HireWise.BLL.Logic.Contracts.Questions;
using HireWise.BLL.Logic.Contracts.Services;
using HireWise.BLL.Logic.Contracts.UserGroup;
using HireWise.BLL.Logic.Contracts.Users;
using HireWise.BLL.Logic.GradeLevels;
using HireWise.BLL.Logic.Questions;
using HireWise.BLL.Logic.Services;
using HireWise.BLL.Logic.TechTransfers;
using HireWise.BLL.Logic.UserGroupLogic;
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
            services.AddScoped<IQuestionLogic, QuestionLogic>();
            services.AddScoped<IGradeLevelLogic, GradeLevelLogic>();
            services.AddScoped<ITechTransferLogic, TechTransferLogic>();
            services.AddScoped<IUserGroupLogic, UserGroupLogic>();
            services.AddScoped<IPasswordService, PasswordService>();

            services.AddAutoMapper(typeof(MapperConfig));
            
            services.AddSingleton<PasswordHasher>();

            return services;
        }

        public static IServiceCollection ConfigureDALDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<ITechTransferRepository, TechTransferRepository>();
            services.AddScoped<IGradeLevelRepository, GradeLevelRepository>();
            services.AddScoped<IUserGroupRepository, UserGroupRepository>();

            return services;
        }
    }
}
