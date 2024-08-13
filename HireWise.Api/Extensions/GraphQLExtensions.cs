using HireWise.Api.GraphQL;

namespace HireWise.Api.Extensions
{
    public static class GraphQLExtensions
    {
        public static IServiceCollection ConfigureGraphQL(this IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType<Queries>()
                .AddMutationType<Mutations>()
                .AddProjections();

            return services;
        }
    }
}
