using HireWise.Common.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.Common.Entities.UserModels.DB
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Email { get; set; }

        public string Password { get; set; }
        public AccessLevel AccessLevel { get; set; }
    }
}
