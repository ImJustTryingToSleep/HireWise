using HireWise.Common.Entities.QuestionModels.DB;

namespace HireWise.DAL.Repository.Contracts
{
    public interface IQuestionRepository
    {
        Task CreateAsync(Question question);
        //Task<List<Question>> GetAsync();
        Task<List<Question>> GetAllPublishedAsync();
        Task<List<Question>> GetAllUnPublishedAsync();
        Task<Question> GetAsync(Guid id);
        Task<List<Question>> GetAsync(int techTrandferId, int gradeLevelId);
        IAsyncEnumerable<Question> GetAsync();
        Task DeleteQuestion(Guid id);
        Task UpdateQuestion(Question question);
    }
}
