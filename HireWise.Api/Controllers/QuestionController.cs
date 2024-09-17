using HireWise.BLL.Logic.Contracts.Questions;
using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.Common.Entities.QuestionModels.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HireWise.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionLogic _questionLogic;

        public QuestionController(IQuestionLogic questionLogic)
        {
            _questionLogic = questionLogic;
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "User")]
        public async Task PostAsync([FromBody] QuestionInputModel questionInputModel)
        {
            await _questionLogic.CreateAsync(questionInputModel);
        }

        [HttpPost]
        [Route("publish")]
        [Authorize(Roles = "Admin")]
        public async Task PublishAsync([FromBody] Guid id)
        {
            await _questionLogic.PublishAsync(id);
        }

        #region "Get"
        [HttpGet]
        [Route("getAll")]
        [Authorize(Roles = "Admin")]
        public  IAsyncEnumerable<Question> GetAsync()
        {
             return _questionLogic.GetAsync();
        }

        [HttpGet]
        [Route("getAllPublished")]
        [AllowAnonymous]
        public IAsyncEnumerable<Question> GetAllPublishedAsync()
        {
            return _questionLogic.GetAllPublishedAsync();
        }

        [HttpGet]
        [Route("getAllUnPublished")]
        [Authorize(Roles = "Admin")]
        public IAsyncEnumerable<Question> GetAllUnPublishedAsync()
        {
            return _questionLogic.GetAllUnPublishedAsync();
        }

        [HttpGet]
        [Route("getById")]
        [AllowAnonymous]
        public async Task<Question> GetAsync(Guid id)
        {
            return await _questionLogic.GetAsync(id);
        }

        [HttpGet("{gradeId}, {techId}")]
        [AllowAnonymous]
        public IAsyncEnumerable<Question> GetAsync(int gradeId, int techId)
        {
            return _questionLogic.GetAsync(gradeId, techId);
        }
        #endregion

        [HttpPut]
        [Route("update")]
        [Authorize(Roles = "Admin")]
        public async Task PutAsync([Required] Guid id, [FromBody] QuestionInputModel inputModel)
        {
            await _questionLogic.UpdateAsync(inputModel, id);
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteAsync(Guid id)
        {
            await _questionLogic.DeleteAsync(id);
        }
    }
}
