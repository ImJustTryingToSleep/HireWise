﻿using HireWise.BLL.Logic.Contracts.Records;
using HireWise.Common.Entities.RecordModels.DB;
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

        [HttpDelete]
        [Route("del")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _recordLogic.DeleteAsync(id);

            return Ok();
        }

        #region Gets

        [HttpGet]
        [Route("getById")]
        public async Task<Record?> GetRecordByIdAsync(Guid id) =>
            await _recordLogic.GetRecordByIdAsync(id);

        [HttpGet]
        [Route("getAll")]
        public IAsyncEnumerable<Record> GetAllRecordsAsync() =>
             _recordLogic.GetAllRecordsAsync();

        [HttpGet]
        [Route("getAllPublished")]
        public IAsyncEnumerable<Record> GetPublishedRecordsAsync() =>
            _recordLogic.GetPublishedRecordsAsync();

        [HttpGet]
        [Route("getPublishedByGradeAndTech")]
        public IAsyncEnumerable<Record> GetPublishedByGradeAndTechIdsAsync(int techTransferId, int gradeId) =>
            _recordLogic.GetPublishedByGradeAndTechIdsAsync(techTransferId, gradeId);

        [HttpGet]
        [Route("getPublishedByTech")]
        public IAsyncEnumerable<Record> GetPublishedByTechIdAsync(int techTransferId) =>
            _recordLogic.GetPublishedByTechIdAsync(techTransferId);

        [HttpGet]
        [Route("getRecordsByUserId")]
        public IAsyncEnumerable<Record> GetRecordsByUserIdAsync(Guid userId) =>
            _recordLogic.GetRecordsByUserIdAsync(userId);

        [HttpGet]
        [Route("getRecordsByGrade")]
        public IAsyncEnumerable<Record> GetRecordsByGradeIdAsync(int gradeId) =>
            _recordLogic.GetRecordsByGradeIdAsync(gradeId);

        [HttpGet]
        [Route("getRecordsByTech")]
        public IAsyncEnumerable<Record> GetRecordsByTechTransferIdAsync(int techTransferId) =>
            _recordLogic.GetRecordsByTechTransferIdAsync(techTransferId);

        #endregion
    }
}
