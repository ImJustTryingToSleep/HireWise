using HireWise.BLL.Logic.Contracts.Questions;
using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.Common.Entities.QuestionModels.InputModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HireWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionLogic _questionLogic;

        [HttpPost]
        [Route("create")]
        public async Task PostAsync([FromBody] QuestionInputModel questionInputModel)
        {
            await _questionLogic.CreateAsync(questionInputModel);
        }
        public QuestionController(IQuestionLogic questionLogic)
        {
            _questionLogic = questionLogic;
        }

        #region "Get"
        [HttpGet]
        [Route("getAll")]
        public IAsyncEnumerable<Question> GetAsync()
        {
           return _questionLogic.GetAsync();
        }

        [HttpGet]
        [Route("getAllPublished")]
        public IAsyncEnumerable<Question> GetAllPublishedAsync()
        {
            return _questionLogic.GetAllPublishedAsync();
        }

        [HttpGet]
        [Route("getAllUnPublished")]
        public IAsyncEnumerable<Question> GetAllUnPublishedAsync()
        {
            return _questionLogic.GetAllUnPublishedAsync();
        }

        [HttpGet]
        [Route("getById")]
        public async Task<Question> GetAsync(Guid id)
        {
            return await _questionLogic.GetAsync(id);
        }

        [HttpGet("{gradeId}, {techId}")]
        public IAsyncEnumerable<Question> GetAsync(int gradeId, int techId)
        {
            return _questionLogic.GetAsync(gradeId, techId);
        }
        #endregion

        [HttpPut]
        [Route("update")]
        public async Task PutAsync([Required] Guid id, [FromBody] QuestionInputModel inputModel)
        {
            await _questionLogic.UpdateAsync(inputModel, id);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task DeleteAsync(Guid id)
        {
            await _questionLogic.DeleteAsync(id);
        }
    }
}
