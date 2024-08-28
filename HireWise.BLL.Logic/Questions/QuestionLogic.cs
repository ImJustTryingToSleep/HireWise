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
                ValidateQustion(questionInputModel);
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
        public IAsyncEnumerable<Question> GetAsync() =>
            _questionRepository.GetAsync();

        public async Task<List<Question>> GetAllPublishedAsync()
        {
            return await _questionRepository.GetAllPublishedAsync();
        }

        public async Task<List<Question>> GetAllUnPublishedAsync()
        {
            return await _questionRepository.GetAllUnPublishedAsync();
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

        public async Task<List<Question>> GetAsync(int gradeId, int techTrasferId)
        {
            return await _questionRepository.GetAsync(gradeId, techTrasferId);
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
                ValidateQustion(questionInputModel);
                var question = _questionRepository.GetAsync(id).Result as Question;

                if (question != null)
                {
                    _mapper.Map(questionInputModel, question);

                    await _questionRepository.UpdateQuestion(question);
                    _logger.LogInformation("Question with Id: {question.Id} was updated", question.Id);
                }
                else
                {
                    _logger.LogError("There is no question with this Id: {id}", id);
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the question");
            }
            
        }

        private void ValidateQustion(QuestionInputModel question)
        {
            var exceptionMessages = new List<string>();

            if (question == null)
            {
                exceptionMessages.Add("Question can't be null");
            }
            if (string.IsNullOrWhiteSpace(question.QuestionName) || string.IsNullOrEmpty(question.QuestionBody))
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
