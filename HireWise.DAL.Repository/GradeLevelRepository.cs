using HireWise.Common.Entities.GradeLevels.DB;
using HireWise.Common.Entities.GradeLevels.InputModels;
using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HireWise.DAL.Repository
{
    public class GradeLevelRepository : IGradeLevelRepository
    {
        private readonly DBContext _dbContext;

        public GradeLevelRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(GradeLevel gradeModel)
        {
            await _dbContext.GradeLevels.AddAsync(gradeModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var gradeLevel = await _dbContext.GradeLevels.FirstOrDefaultAsync(g => g.Id == id);
            _dbContext.GradeLevels.Remove(gradeLevel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<GradeLevel>> GetAsync()
        {
            return await _dbContext.GradeLevels.ToListAsync();
        }

        public async Task<GradeLevel> GetAsync(int id)
        {
            return await _dbContext.GradeLevels.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task UpdateAsync(GradeLevel gradeLevel)
        {
            _dbContext.Entry(gradeLevel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
