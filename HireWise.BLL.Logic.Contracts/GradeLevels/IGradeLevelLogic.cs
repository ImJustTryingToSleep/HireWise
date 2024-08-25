using HireWise.Common.Entities.GradeLevels.DB;
using HireWise.Common.Entities.GradeLevels.InputModels;

namespace HireWise.BLL.Logic.Contracts.GradeLevels
{
    public interface IGradeLevelLogic
    {
        Task CreateAsync(GradeLevelInputModel gradeLevelInputModel);
        Task<List<GradeLevel>> GetAsync();
        Task<GradeLevel> GetAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(GradeLevelInputModel gradeLevelInput, int id);
    }
}
