using HireWise.BLL.Logic.Contracts.ITechTransferLogic;
using HireWise.Common.Entities.TechTransferModels.DB;
using HireWise.Common.Entities.TechTransferModels.InputModels;
using Microsoft.AspNetCore.Mvc;

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

        //GET: api/<TechTransferController>
        [HttpGet]
        [Route("getAll")]
        public async Task<List<TechTransfer>> GetAsync()
        {
            return await _techTransferLogic.GetAsync();
        }

        // GET api/<TechTransferController>/5
        [HttpGet]
        [Route("getById")]
        public async Task<TechTransfer> GetAsync(int id)
        {
            return await _techTransferLogic.GetAsync(id);
        }

        // POST api/<TechTransferController>
        [HttpPost]
        [Route("create")]
        public async Task PostAsync([FromBody] TechTransferInputModel techTransferInputModel)
        {
            await _techTransferLogic.CreateTechTransferAsync(techTransferInputModel);
        }

        // PUT api/<TechTransferController>/5
        [HttpPut]
        [Route("update")]
        public async Task PutAsync([FromBody] TechTransferInputModel techModel, int id)
        {
            await _techTransferLogic.UpdateAsync(techModel, id);
        }

        // DELETE api/<TechTransferController>/5
        [HttpDelete]
        [Route("delete")]
        public async Task DeleteAsync(int id)
        {
            await _techTransferLogic.DeleteTechTransferAsync(id);
        }
    }
}
