using HireWise.Api.GraphQL;

namespace HireWise.Api.Extensions
{
    public static class GraphQLExtensions
    {
        public static IServiceCollection ConfigureGrafGL(this IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType<Queries>();

            return services;
        }
    }
}
