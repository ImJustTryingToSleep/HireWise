using HireWise.Common.Entities.RoleModels.DB;

namespace HireWise.Common.Entities.UserModels.DB
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Role> Roles { get;} = [];
        public List<User>? Users { get; set; }
    }
}
