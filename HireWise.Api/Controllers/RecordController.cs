using HireWise.BLL.Logic.Contracts.Records;
using HireWise.Common.Entities.RecordModels.DB;
using HireWise.Common.Entities.RecordModels.InputModels;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "User")]
        public async Task AddNewAsync([FromBody] RecordInputModel record) =>
            await _recordLogic.CreateAsync(record);

        [HttpPut]
        [Route("update")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] RecordInputModel record)
        {
            await _recordLogic.UpdateAsync(record, id);

            return Ok();
        }

        [HttpDelete]
        [Route("del")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _recordLogic.DeleteAsync(id);

            return Ok();
        }

        #region Gets

        [HttpGet]
        [Route("getById")]
        [Authorize(Roles = "User")]
        public async Task<Record?> GetRecordByIdAsync(Guid id) =>
            await _recordLogic.GetRecordByIdAsync(id);

        [HttpGet]
        [Route("getAll")]
        [Authorize(Roles = "Admin")]
        public IAsyncEnumerable<Record> GetAllRecordsAsync() =>
             _recordLogic.GetAllRecordsAsync();

        [HttpGet]
        [Route("getAllPublished")]
        [Authorize(Roles = "Admin")]
        public IAsyncEnumerable<Record> GetPublishedRecordsAsync() =>
            _recordLogic.GetPublishedRecordsAsync();

        [HttpGet]
        [Route("getAllPublished")]
        [Authorize(Roles = "Admin")]
        public IAsyncEnumerable<Record> GetUnpublishedRecordsAsync() =>
            _recordLogic.GetUnpublishedRecordsAsync();

        [HttpGet]
        [Route("getPublishedByGradeAndTech")]
        [Authorize(Roles = "User")]
        public IAsyncEnumerable<Record> GetPublishedByGradeAndTechIdsAsync(int techTransferId, int gradeId) =>
            _recordLogic.GetPublishedByGradeAndTechIdsAsync(techTransferId, gradeId);

        [HttpGet]
        [Route("getPublishedByTech")]
        [Authorize(Roles = "User")]
        public IAsyncEnumerable<Record> GetPublishedByTechIdAsync(int techTransferId) =>
            _recordLogic.GetPublishedByTechIdAsync(techTransferId);

        [HttpGet]
        [Route("getRecordsByUserId")]
        [Authorize(Roles = "User")]
        public IAsyncEnumerable<Record> GetRecordsByUserIdAsync(Guid userId) =>
            _recordLogic.GetRecordsByUserIdAsync(userId);

        [HttpGet]
        [Route("getRecordsByGrade")]
        [Authorize(Roles = "User")]
        public IAsyncEnumerable<Record> GetRecordsByGradeIdAsync(int gradeId) =>
            _recordLogic.GetRecordsByGradeIdAsync(gradeId);

        [HttpGet]
        [Route("getRecordsByTech")]
        [Authorize(Roles = "User")]
        public IAsyncEnumerable<Record> GetRecordsByTechTransferIdAsync(int techTransferId) =>
            _recordLogic.GetRecordsByTechTransferIdAsync(techTransferId);

        #endregion
    }
}
