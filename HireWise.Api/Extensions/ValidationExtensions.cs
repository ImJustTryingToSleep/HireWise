using FluentValidation;
using HireWise.Common.Entities.ValidationModels;

namespace HireWise.Api.Extensions
{
    public static class ValidationExtensions
    {
        public static IServiceCollection ConfigureValidationDependencies(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<QuestionValidator>();
            services.AddValidatorsFromAssemblyContaining<UserValidator>();
            services.AddValidatorsFromAssemblyContaining<RecordValidator>();
            services.AddValidatorsFromAssemblyContaining<LoginValidator>();

            return services;
        }
    }
}
