using HireWise.BLL.Logic.Contracts.TechTransfers;
using HireWise.Common.Entities.TechTransferModels.DB;
using HireWise.Common.Entities.TechTransferModels.InputModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HireWise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechTransferController : ControllerBase
    {

        private readonly ITechTransferLogic _techTransferLogic;

        public TechTransferController(ITechTransferLogic techTransferLogic)
        {
            _techTransferLogic = techTransferLogic;
        }

        [HttpGet]
        [Route("getAll")]
        public IAsyncEnumerable<TechTransfer> GetAsync()
        {
            return _techTransferLogic.GetAsync();
        }

        [HttpGet]
        [Route("getById")]
        public async Task<TechTransfer> GetAsync([Required] int id)
        {
            return await _techTransferLogic.GetAsync(id);
        }

        [HttpPost]
        [Route("create")]
        public async Task PostAsync([FromBody] TechTransferInputModel techTransferInputModel)
        {
            await _techTransferLogic.CreateAsync(techTransferInputModel);
        }

        [HttpPut]
        [Route("update")]
        public async Task PutAsync([Required] int id, [FromBody] TechTransferInputModel techModel)
        {
            await _techTransferLogic.UpdateAsync(techModel, id);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task DeleteAsync([Required] int id)
        {
            await _techTransferLogic.DeleteAsync(id);
        }
    }
}
