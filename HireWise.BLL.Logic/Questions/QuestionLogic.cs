using AutoMapper;
using HireWise.BLL.Logic.Contracts.Questions;
using HireWise.BLL.Logic.Contracts.Users;
using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.Common.Entities.QuestionModels.InputModels;
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

        /// <summary>
        /// Создание вопроса
        /// </summary>
        /// <param name="questionInputModel"></param>
        /// <returns></returns>
        public async Task CreateAsync(QuestionInputModel questionInputModel)
        {
            try
            {
                var question = _mapper.Map<Question>(questionInputModel);

                await _questionRepository.CreateAsync(question);
                _logger.LogInformation("Question was created with ID: {question.Id}", question.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the question");
            }
        }

        #region "Get"
        /// <summary>
        /// Поулчение всех вопросов
        /// </summary>
        /// <returns></returns>
        public IAsyncEnumerable<Question> GetAsync()
        {
            return _questionRepository.GetAsync();
        }

        /// <summary>
        /// Получение всех опубликованных
        /// </summary>
        /// <returns></returns>
        public IAsyncEnumerable<Question> GetAllPublishedAsync()
        {
            return _questionRepository.GetAllPublichedAsync();
        }

        /// <summary>
        /// Получение всех неопубликованных
        /// </summary>
        /// <returns></returns>
        public IAsyncEnumerable<Question> GetAllUnPublishedAsync()
        {
            return _questionRepository.GetAllUnPublichedAsync();
        }

        /// <summary>
        /// Получение вопроса по Id
        /// </summary>
        /// <returns></returns>
        public async Task<Question> GetAsync(Guid id)
        {
            try
            {
                return await _questionRepository.GetAsync(id);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "There is no question with this Id");
                throw;
            }
        }

        /// <summary>
        /// Получение опубликованных вопросов по предметной области и уровню
        /// </summary>
        /// <returns></returns>
        public IAsyncEnumerable<Question> GetAsync(int gradeId, int techTrasferId)
        {
            return _questionRepository.GetAsync(gradeId, techTrasferId);
        }
        #endregion

        /// <summary>
        /// Удаление вопроса
        /// </summary>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _questionRepository.DeleteQuestion(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There is no question with this Id");
                throw;
            }
        }

        /// <summary>
        /// Обновление вопроса
        /// </summary>
        /// <returns></returns>
        public async Task UpdateAsync(QuestionInputModel questionInputModel, Guid id)
        {
            try
            {
                var question = _questionRepository.GetAsync(id).Result;

                if (question is null)
                {
                    _logger.LogError("There is no record with Id: {question.Id}", question.Id);
                    throw new NullReferenceException("Question is null");
                }

                _mapper.Map(questionInputModel, question);

                await _questionRepository.UpdateQuestion(question);
                _logger.LogDebug("Question with Id: {question.Id} was updated", question.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the question");
                throw;
            }
            
        }

        /// <summary>
        /// Публикация вопроса
        /// </summary>
        /// <returns></returns>
        public async Task PublishAsync(Guid id)
        {
            try
            {
                var question = _questionRepository.GetAsync(id).Result;

                if (question is null)
                {
                    _logger.LogError("There is no question with Id: {qustion.Id}", id);
                }

                question.IsPublished = true;
                await _questionRepository.UpdateQuestion(question);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error while posting question");
                throw;
            }
        }
    }
}
