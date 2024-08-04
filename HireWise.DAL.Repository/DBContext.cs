using HireWise.Common.Entities.GradeLevels;
using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.Common.Entities.RecordModels.DB;
using HireWise.Common.Entities.TechTransferModels;
using HireWise.Common.Entities.UserModels.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.DAL.Repository
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Record> Records { get; set; } = null!;
        public DbSet<TechTransfer> TechTransfers { get; set; } = null!;
        public DbSet<GradeLevel> GradeLevel { get; set; } = null!;

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
    }
}
