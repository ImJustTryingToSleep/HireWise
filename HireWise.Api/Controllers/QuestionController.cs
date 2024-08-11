using HireWise.BLL.Logic.Contracts.Questions;
using HireWise.BLL.Logic.Questions;
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
        public async Task<List<Question>> GetAsync()
        {
            return await _questionLogic.GetAllAsync();
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
        public async Task<Question> GetQuestionAsync(Guid id)
        {
            return await _questionLogic.GetQuestionAsync(id);
        }

        [HttpGet("{gradeId}, {techId}")]
        public async Task<List<Question>> GetByGradeAndTech(int gradeId, int techId)
        {
            return await _questionLogic.GetByGradeAndTechTransferAsync(gradeId, techId);
        }
        #endregion

        // POST api/<QuestionController>/create
        [HttpPost]
        [Route("create")]
        public async Task PostAsync([FromBody] QuestionCreateInputModel questionInputModel)
        {
            await _questionLogic.CreateQustionAsync(questionInputModel);
        }

        // PUT api/<QuestionController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _questionLogic.DeleteQuestion(id);
        }
    }
}
