using HireWise.BLL.Logic.Contracts.GradeLevels;
using HireWise.Common.Entities.GradeLevels.InputModels;
using HireWise.DAL.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HireWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeLevelController : ControllerBase
    {
        private readonly IGradeLevelLogic _gradeLevelLogic;

        public GradeLevelController(IGradeLevelLogic gradeLevelLogic)
        {
            _gradeLevelLogic = gradeLevelLogic;
        }
        // GET: api/<GradeLevelController>
        //[HttpGet]
        //public IEnumerable<string> GetAsync()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<GradeLevelController>/5
        //[HttpGet("{id}")]
        //public string GetAsync(int id)
        //{
        //    return "value";
        //}

        // POST api/<GradeLevelController>
        [HttpPost]
        [Route("create")]
        public async Task Post([FromBody] GradeLevelInputModel model)
        {
            await _gradeLevelLogic.CreateGradeAsync(model);
        }

        //// PUT api/<GradeLevelController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<GradeLevelController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
