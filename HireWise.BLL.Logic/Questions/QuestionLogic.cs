using AutoMapper;
using HireWise.BLL.Logic.Contracts.Questions;
using HireWise.BLL.Logic.Contracts.Users;
using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.Common.Entities.QuestionModels.InputModels;
using HireWise.Common.Entities.UserModels.DB;
using HireWise.DAL.Repository.Contracts;
using Microsoft.Extensions.Logging;

namespace HireWise.BLL.Logic.Questions
{
    public class QuestionLogic : IQuestionLogic
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUserLogic _userLogic;
        private readonly ILogger<QuestionLogic> _logger;
        private readonly IMapper _mapper;

        public QuestionLogic(
            IQuestionRepository questionRepository, 
            IUserLogic userLogic,
            ILogger<QuestionLogic> logger,
            IMapper mapper)
        {
            _questionRepository = questionRepository;
            _userLogic = userLogic;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateQustionAsync(QuestionCreateInputModel questionInputModel)
        {
            try
            {
                ValidateQustion(questionInputModel);
                var question = _mapper.Map<Question>(questionInputModel);

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

        public async Task UpdateQuestion(QuestionCreateInputModel questionInputModel, Guid id) // Переписывать методы без Task?
        {
            var question = _questionRepository.GetQuestionAsync(id).Result as Question;

            question.QuestionName = questionInputModel.QuestionName;
            question.QuestionBody = questionInputModel.QuestionBody;
            question.GradeLevelId = questionInputModel.GradeLevelId;
            question.TechTransferId = questionInputModel.TechTransferId;

            await _questionRepository.UpdateQuestion(question);
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
