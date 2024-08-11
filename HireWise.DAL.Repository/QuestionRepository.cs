using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.Common.Entities.QuestionModels.InputModels;
using HireWise.DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<List<Question>> GetAllAsync()
        {
            return await _dbContext.Questions.ToListAsync();
        }

        public async Task<List<Question>> GetAllPublichedAsync()
        {
            var publishedQuestions = _dbContext.Questions.Where(q => q.IsPublished == true);
            return await publishedQuestions.ToListAsync();
        }

        public async Task<List<Question>> GetAllUnPublichedAsync()
        {
            var publishedQuestions = _dbContext.Questions.Where(q => q.IsPublished == false);
            return await publishedQuestions.ToListAsync();
        }

        public async Task<Question> GetQuestionAsync(Guid id)
        {
            return await _dbContext.Questions.FirstOrDefaultAsync(q => q.Id == id); // Добавить обработку при случае, если вопрос null
        }

        public async Task<List<Question>> GetAllByTechTransferAndGradeLevelAsync(int techTrandferId, int gradeLevelId)
        {
            var questions = _dbContext.Questions.Where(q => q.GradeId == gradeLevelId && q.TechTransferId == techTrandferId && q.IsPublished == true);
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
    }
}
