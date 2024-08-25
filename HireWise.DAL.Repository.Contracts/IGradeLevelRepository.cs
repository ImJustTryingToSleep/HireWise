using HireWise.Common.Entities.GradeLevels.DB;

namespace HireWise.DAL.Repository.Contracts
{
    public interface IGradeLevelRepository
    {
        Task CreateAsync(GradeLevel gradeModel);
        Task<List<GradeLevel>> GetAsync();
        Task<GradeLevel> GetAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(GradeLevel gradeLevel);
    }
}
