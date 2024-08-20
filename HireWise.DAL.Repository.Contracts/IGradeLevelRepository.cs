using HireWise.Common.Entities.GradeLevels.DB;
using HireWise.Common.Entities.GradeLevels.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.DAL.Repository.Contracts
{
    public interface IGradeLevelRepository
    {
        Task CreateAsync(GradeLevel gradeModel);
        Task DeleteAsync(int id);
        Task<List<GradeLevel>> GetAsync();
        Task<GradeLevel> GetAsync(int id);
        Task Update(GradeLevel gradeLevel);
    }
}
