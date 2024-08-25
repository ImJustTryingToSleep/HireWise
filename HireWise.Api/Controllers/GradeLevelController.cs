using HireWise.BLL.Logic.Contracts.GradeLevels;
using HireWise.Common.Entities.GradeLevels.DB;
using HireWise.Common.Entities.GradeLevels.InputModels;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("getAll")]
        public async Task<List<GradeLevel>> GetAsync()
        {
            return await _gradeLevelLogic.GetAsync();
        }

        [HttpGet]
        [Route("getById")]
        public async Task<GradeLevel> GetAsync(int id)
        {
            return await _gradeLevelLogic.GetAsync(id);
        }

        [HttpPost]
        [Route("create")]
        public async Task Post([FromBody] GradeLevelInputModel model)
        {
            await _gradeLevelLogic.CreateAsync(model);
        }

        [HttpPut]
        [Route("update")]
        public async Task PutAsync(int id, [FromBody] GradeLevelInputModel gradeLvl)
        {
            await _gradeLevelLogic.UpdateAsync(gradeLvl, id);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task DeleteAsync(int id)
        {
            await _gradeLevelLogic.DeleteAsync(id);
        }
    }
}
