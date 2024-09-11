namespace HireWise.Common.Entities.UserModels.DB
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SecretWord { get; set; }
        public int UserGroupId { get; set; }
        public bool IsBanned { get; set; } = false;
        public UserGroup UserGroup { get; set; }
    }
}
