using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireWise.Common.Entities.UserModels.DB;

namespace HireWise.Common.Entities.RoleModels.DB
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserGroup>? UserGroups { get; } = [];
    }
}
