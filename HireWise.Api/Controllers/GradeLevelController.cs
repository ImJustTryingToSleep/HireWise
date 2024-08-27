using HireWise.BLL.Logic.Contracts.GradeLevels;
using HireWise.Common.Entities.GradeLevels.DB;
using HireWise.Common.Entities.GradeLevels.InputModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

        [HttpPost]
        [Route("create")]
        public async Task Post([FromBody] GradeLevelInputModel model)
        {
            await _gradeLevelLogic.CreateAsync(model);
        }

        [HttpGet]
        [Route("getAll")]
        public IAsyncEnumerable<GradeLevel> GetAsync()
        {
            return _gradeLevelLogic.GetAsync();
        }

        [HttpGet]
        [Route("getById")]
        public async Task<GradeLevel> GetAsync([Required] int id)
        {
            return await _gradeLevelLogic.GetAsync(id);
        }

        [HttpPut]
        [Route("update")]
        public async Task PutAsync([Required] int id, [FromBody] GradeLevelInputModel gradeLvl)
        {
            await _gradeLevelLogic.UpdateAsync(gradeLvl, id);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task DeleteAsync([Required] int id)
        {
            await _gradeLevelLogic.DeleteAsync(id);
        }
    }
}
