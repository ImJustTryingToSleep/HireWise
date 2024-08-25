using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.Common.Entities.QuestionModels.InputModels;

namespace HireWise.BLL.Logic.Contracts.Questions
{
    public interface IQuestionLogic
    {
        //Task<List<Question>> GetAsync();
        Task<List<Question>> GetAllPublishedAsync();
        Task<List<Question>> GetAllUnPublishedAsync();
        Task<Question> GetAsync(Guid id);
        Task<List<Question>> GetAsync(int gradeId, int techTrasferId);
        IAsyncEnumerable<Question> GetAsync();
        Task CreateAsync(QuestionInputModel questionInputModel);
        Task UpdateAsync(QuestionInputModel questionInputModel, Guid id);
        Task DeleteAsync(Guid id);
    }
}
