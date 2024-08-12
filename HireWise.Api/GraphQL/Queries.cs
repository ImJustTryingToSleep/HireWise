using HireWise.Common.Entities.UserModels.DB;
using HireWise.DAL.Repository;

namespace HireWise.Api.GraphQL
{
    public class Queries
    {
        [UseProjection]
        public IQueryable<User> Read([Service] DBContext context) =>
            context.Users;
    }
}
