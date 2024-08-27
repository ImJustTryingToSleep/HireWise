using HireWise.Common.Entities.QuestionModels.DB;

namespace HireWise.DAL.Repository.Contracts
{
    public interface IQuestionRepository
    {
        Task CreateAsync(Question question);
        IAsyncEnumerable<Question> GetAllPublichedAsync();
        IAsyncEnumerable<Question> GetAllUnPublichedAsync();
        IAsyncEnumerable<Question> GetAsync(int techTrandferId, int gradeLevelId);
        IAsyncEnumerable<Question> GetAsync();
        Task<Question> GetAsync(Guid id);
        Task DeleteQuestion(Guid id);
        Task UpdateQuestion(Question question);
    }
}
