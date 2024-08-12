using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.Common.Entities.QuestionModels.InputModels;

namespace HireWise.BLL.Logic.Contracts.Questions
{
    public interface IQuestionLogic
    {
        Task CreateQustionAsync(QuestionCreateInputModel questionInputModel);
        Task<List<Question>> GetAllAsync();
        Task<List<Question>> GetAllPublishedAsync();
        Task<List<Question>> GetAllUnPublishedAsync();
        Task<Question> GetQuestionAsync(Guid id);
        Task<List<Question>> GetByGradeAndTechTransferAsync(int gradeId, int techTrasferId);
        Task DeleteQuestion(Guid id);
        Task UpdateQuestion(QuestionCreateInputModel questionInputModel, Guid id);
    }
}
