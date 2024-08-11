using HireWise.BLL.Logic.Contracts.Questions;
using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.Common.Entities.QuestionModels.InputModels;
using HireWise.DAL.Repository.Contracts;
using Microsoft.Extensions.Logging;

namespace HireWise.BLL.Logic.Questions
{
    public class QuestionLogic : IQuestionLogic
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ILogger<QuestionLogic> _logger;

        public QuestionLogic(
            IQuestionRepository questionRepository, 
            ILogger<QuestionLogic> logger)
        {
            _questionRepository = questionRepository;
            _logger = logger;
        }

        public async Task CreateQustionAsync(QuestionCreateInputModel questionInputModel)
        {
            try
            {
                ValidateQustion(questionInputModel);
                var question = new Question
                {
                    QuestionName = questionInputModel.QuestionName,
                    QuestionBody = questionInputModel.QuestionBody,
                    GradeId = questionInputModel.GradeId,
                    TechTransferId = questionInputModel.TechTransferId,
                    UserId = questionInputModel.UserId,
                };

                await _questionRepository.CreateAsync(question);
                _logger.LogInformation("Question ID: {question.Id}", question.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при создании вопроса");
            }
        }

        #region "Get"
        public async Task<List<Question>> GetAllAsync()
        {
            return await _questionRepository.GetAllAsync();
        }

        public async Task<List<Question>> GetAllPublishedAsync()
        {
            return await _questionRepository.GetAllPublichedAsync();
        }

        public async Task<List<Question>> GetAllUnPublishedAsync()
        {
            return await _questionRepository.GetAllUnPublichedAsync();
        }

        public async Task<Question> GetQuestionAsync(Guid id)
        {
            return await _questionRepository.GetQuestionAsync(id);
        }

        public async Task<List<Question>> GetByGradeAndTechTransferAsync(int gradeId, int techTrasferId)
        {
            return await _questionRepository.GetAllByTechTransferAndGradeLevelAsync(gradeId, techTrasferId);
        }
        #endregion

        public async Task DeleteQuestion(Guid id)
        {
            await _questionRepository.DeleteQuestion(id);
        }

        //-------------------------------------------------Скорее всего не работает--------------------------------------------------
        private void ValidateQustion(QuestionCreateInputModel question)
        {
            var exceptionMessages = new List<string>();

            if (question == null)
            {
                exceptionMessages.Add("Вопрос не может быть пустым");
            }
            if (question.QuestionName == null || question.QuestionBody == null)
            {
                exceptionMessages.Add("Заголовок или тело вопроса не могут быть пустыми");
            }
            if (exceptionMessages.Any())
            {
                foreach (var exception in exceptionMessages)
                {
                    _logger.LogError(exception);
                }
                throw new ArgumentException("Произошла ошибка при создании вопроса");
            }
        }
    }
}
