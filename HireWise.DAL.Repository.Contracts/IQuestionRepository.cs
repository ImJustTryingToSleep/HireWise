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
        Task<List<Question>> GetAllAsync();
        Task<List<Question>> GetAllPublichedAsync();
        Task<List<Question>> GetAllUnPublichedAsync();
        Task<Question> GetQuestionAsync(Guid id);
        Task<List<Question>> GetAllByTechTransferAndGradeLevelAsync(int techTrandferId, int gradeLevelId);
        Task DeleteQuestion(Guid id);
        Task UpdateQuestion(Question question);
    }
}
