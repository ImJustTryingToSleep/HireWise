using HireWise.Common.Entities.QuestionModels.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.DAL.Repository.Contracts
{
    public interface IQuestionRepository
    {
        Task CreateAsync(Question question);
        //Task<List<Question>> GetAsync();
        Task<List<Question>> GetAllPublichedAsync();
        Task<List<Question>> GetAllUnPublichedAsync();
        Task<Question> GetAsync(Guid id);
        Task<List<Question>> GetAsync(int techTrandferId, int gradeLevelId);
        IAsyncEnumerable<Question> GetAsync();
        Task DeleteQuestion(Guid id);
        Task UpdateQuestion(Question question);
    }
}
