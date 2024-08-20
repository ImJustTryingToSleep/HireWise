using HireWise.Common.Entities.GradeLevels.DB;
using HireWise.Common.Entities.GradeLevels.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.BLL.Logic.Contracts.GradeLevels
{
    public interface IGradeLevelLogic
    {
        Task CreateAsync(GradeLevelInputModel gradeLevelInputModel);
        Task DeleteAsync(int id);
        Task<List<GradeLevel>> GetAsync();
        Task<GradeLevel> GetAsync(int id);
        Task UpdateAsync(GradeLevelInputModel gradeLevelInput, int id);
    }
}
