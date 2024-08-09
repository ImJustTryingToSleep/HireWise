namespace HireWise.Common.Entities.UserModels.DB
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }
    }
}
