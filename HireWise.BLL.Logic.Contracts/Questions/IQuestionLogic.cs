using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.Common.Entities.QuestionModels.InputModels;

namespace HireWise.BLL.Logic.Contracts.Questions
{
    public interface IQuestionLogic
    {
        IAsyncEnumerable<Question> GetAllPublishedAsync();
        IAsyncEnumerable<Question> GetAllUnPublishedAsync();
        IAsyncEnumerable<Question> GetAsync(int gradeId, int techTrasferId);
        IAsyncEnumerable<Question> GetAsync();
        Task<Question> GetAsync(Guid id);
        Task CreateAsync(QuestionInputModel questionInputModel);
        Task UpdateAsync(QuestionInputModel questionInputModel, Guid id);
        Task DeleteAsync(Guid id);
        Task PublishAsync(Guid id);
    }
}
