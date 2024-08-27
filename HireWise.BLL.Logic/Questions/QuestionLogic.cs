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

        public async Task CreateAsync(QuestionInputModel questionInputModel)
        {
            try
            {
                ValidateQuestion(questionInputModel);
                var question = _mapper.Map<Question>(questionInputModel);

                await _questionRepository.CreateAsync(question);
                _logger.LogInformation("Question was created with ID: {question.Id}", question.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the question");
            }
        } //log+

        #region "Get"
        public IAsyncEnumerable<Question> GetAsync()
        {
            return _questionRepository.GetAsync();
        }

        public IAsyncEnumerable<Question> GetAllPublishedAsync()
        {
            return _questionRepository.GetAllPublichedAsync();
        }

        public IAsyncEnumerable<Question> GetAllUnPublishedAsync()
        {
            return _questionRepository.GetAllUnPublichedAsync();
        }

        public async Task<Question> GetAsync(Guid id) // log+
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

        public IAsyncEnumerable<Question> GetAsync(int gradeId, int techTrasferId)
        {
            return _questionRepository.GetAsync(gradeId, techTrasferId);
        }
        #endregion

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
        } //log+

        public async Task UpdateAsync(QuestionInputModel questionInputModel, Guid id) // log+
        {
            try
            {
                ValidateQuestion(questionInputModel);
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

        private void ValidateQuestion(QuestionInputModel question)
        {
            var exceptionMessages = new List<string>();

            if (question == null)
            {
                exceptionMessages.Add("Question can't be null");
            }
            if (string.IsNullOrWhiteSpace(question.QuestionName) || string.IsNullOrWhiteSpace(question.QuestionBody))
            {
                exceptionMessages.Add("QuestionName or QuestionBody can't be null");
            }
            if (exceptionMessages.Any())
            {
                foreach (var exception in exceptionMessages)
                {
                    _logger.LogError(exception);
                }
                throw new ArgumentException("An error occurred while validating the question");
            }
        }
    }
}
