using HireWise.BLL.Logic.Contracts.Records;
using HireWise.Common.Entities.RecordModels.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace HireWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordLogic _recordLogic;

        public RecordController(IRecordLogic recordLogic)
        {
            _recordLogic = recordLogic;
        }

        [HttpPost]
        [Route("create")]
        public async Task AddNewAsync([FromBody] RecordInputModel record) =>
            await _recordLogic.CreateAsync(record);

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] RecordInputModel record)
        {
            await _recordLogic.UpdateAsync(record, id);

           return Ok();
        }
    }
}
