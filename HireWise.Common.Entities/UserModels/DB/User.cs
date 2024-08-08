using HireWise.Common.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace HireWise.Common.Entities.UserModels.DB
{
    public class User
    {
        public Guid Id { get; set; }

        public string Login { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public AccessLevel AccessLevel { get; set; }
    }
}
