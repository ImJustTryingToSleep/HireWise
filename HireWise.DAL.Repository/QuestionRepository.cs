using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HireWise.DAL.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly HireWiseDBContext _dbContext;

        public QuestionRepository(HireWiseDBContext dbContext)
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
        public IAsyncEnumerable<Question> GetAsync() => 
            _dbContext.Questions.AsAsyncEnumerable();

        public async Task<List<Question>> GetAllPublishedAsync()
        {
            var publishedQuestions = _dbContext.Questions.Where(q => q.IsPublished == true);
            return await publishedQuestions.ToListAsync();
        }

        public async Task<List<Question>> GetAllUnPublishedAsync()
        {
            var publishedQuestions = _dbContext.Questions.Where(q => q.IsPublished == false);
            return await publishedQuestions.ToListAsync();
        }

        public async Task<Question> GetAsync(Guid id)
        {
            return await _dbContext.Questions.FirstOrDefaultAsync(q => q.Id == id); // Добавить обработку при случае, если вопрос null
        }

        public async Task<List<Question>> GetAsync(int techTransferId, int gradeLevelId)
        {
            var questions = _dbContext.Questions.Where(q => q.GradeLevelId == gradeLevelId && q.TechTransferId == techTransferId && q.IsPublished == true);
            return await questions.ToListAsync();
        }  //Переименовать? Вынести tech и grade в отдельную сущность?
        #endregion

        #region "Delete"
        public async Task DeleteQuestion(Guid id)
        {
            var question = await _dbContext.Questions.FirstOrDefaultAsync(q => q.Id == id);
            _dbContext.Remove(question);
            await _dbContext.SaveChangesAsync();
        }
        #endregion

        public async Task UpdateQuestion (Question question)
        {
            //var qest = await GetAsync(question.Id);
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
