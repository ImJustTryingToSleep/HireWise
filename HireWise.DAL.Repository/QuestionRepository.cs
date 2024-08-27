using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HireWise.DAL.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DBContext _dbContext;

        public QuestionRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region "Post"
        public async Task CreateAsync(Question question)
        {
            await _dbContext.Questions.AddAsync(question);
            await _dbContext.SaveChangesAsync();
        }
        #endregion

        #region "Get"
        public IAsyncEnumerable<Question> GetAsync()
        {
            return _dbContext.Questions.AsAsyncEnumerable();
        }

        public IAsyncEnumerable<Question> GetAllPublichedAsync()
        {
            return _dbContext.Questions.Where(q => q.IsPublished == true).AsAsyncEnumerable();
        }

        public IAsyncEnumerable<Question> GetAllUnPublichedAsync()
        {
            return _dbContext.Questions.Where(q => q.IsPublished == false).AsAsyncEnumerable();
        }

        public async Task<Question?> GetAsync(Guid id)
        {
            return await _dbContext.Questions.FirstOrDefaultAsync(q => q.Id == id); // Добавить обработку при случае, если вопрос null
        }

        public IAsyncEnumerable<Question> GetAsync(int techTransferId, int gradeLevelId)
        {
            return _dbContext.Questions.Where(q => q.GradeLevelId == gradeLevelId && q.TechTransferId == techTransferId && q.IsPublished == true).AsAsyncEnumerable();
        }
        #endregion

        #region "Delete"
        public async Task DeleteQuestion(Guid id)
        {
            var question = await GetAsync(id);
            _dbContext.Remove(question);
            await _dbContext.SaveChangesAsync();
        }
        #endregion

        public async Task UpdateQuestion (Question question)
        {
            _dbContext.Entry(question).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        //public static async IAsyncEnumerable<T> ToAsyncEnumerable<T>(List<T> list)
        //{
        //    foreach (var item in list)
        //    {
        //        yield return item;
        //    }
        //}
    }
}
