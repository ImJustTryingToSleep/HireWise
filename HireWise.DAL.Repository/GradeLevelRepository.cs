using HireWise.Common.Entities.GradeLevels.DB;
using HireWise.Common.Entities.GradeLevels.InputModels;
using HireWise.DAL.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.DAL.Repository
{
    public class GradeLevelRepository : IGradeLevelRepository
    {
        private readonly DBContext _dbContext;

        public GradeLevelRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateGradeAsync(GradeLevel gradeModel)
        {
            await _dbContext.GradeLevels.AddAsync(gradeModel);
            await _dbContext.SaveChangesAsync();
        }
    }
}
