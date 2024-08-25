using HireWise.BLL.Logic.Contracts.Questions;
using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.Common.Entities.QuestionModels.InputModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HireWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionLogic _questionLogic;

        public QuestionController(IQuestionLogic questionLogic)
        {
            _questionLogic = questionLogic;
        }

        #region "Get"
        // GET: api/<QuestionController>
        [HttpGet]
        [Route("getAll")]
        public async IAsyncEnumerable<Question> GetAsync()
        {
           var questions = _questionLogic.GetAsync();
            //yield return (Question)questions;
            await foreach (var item in questions)
            {
                yield return item;
            }
        }

        [HttpGet]
        [Route("getAllPublished")]
        public async Task<List<Question>> GetAllPublishedAsync()
        {
            return await _questionLogic.GetAllPublishedAsync();
        }

        [HttpGet]
        [Route("getAllUnPublished")]
        public async Task<List<Question>> GetAllUnPublishedAsync()
        {
            return await _questionLogic.GetAllUnPublishedAsync();
        }

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        public async Task<Question> GetAsync(Guid id)
        {
            return await _questionLogic.GetAsync(id);
        }

        [HttpGet("{gradeId}, {techId}")]
        public async Task<List<Question>> GetAsync(int gradeId, int techId)
        {
            return await _questionLogic.GetAsync(gradeId, techId);
        }
        #endregion

        // POST api/<QuestionController>/create
        [HttpPost]
        [Route("create")]
        public async Task PostAsync([FromBody] QuestionInputModel questionInputModel)
        {
            await _questionLogic.CreateAsync(questionInputModel);
        }

        // PUT api/<QuestionController>/5
        [HttpPut]
        [Route("update")]
        public async Task PutAsync([FromBody] QuestionInputModel inputModel, Guid id)
        {
            await _questionLogic.UpdateAsync(inputModel, id);
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _questionLogic.DeleteAsync(id);
        }
    }
}
