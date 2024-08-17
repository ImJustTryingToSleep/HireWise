using HireWise.BLL.Logic.Contracts.ITechTransferLogic;
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
        // GET: api/<TechTransferController>
        //[HttpGet]
        //public IEnumerable<string> GetAsync()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<TechTransferController>/5
        //[HttpGet("{id}")]
        //public string GetAsync(int id)
        //{
        //    return "value";
        //}

        // POST api/<TechTransferController>
        [HttpPost]
        [Route("create")]
        public async Task Post([FromBody] TechTransferInputModel techTransferInputModel)
        {
            await _techTransferLogic.CreateTechTransferAsync(techTransferInputModel);
        }

        //// PUT api/<TechTransferController>/5
        //[HttpPut("{id}")]
        //public void PutAsync(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<TechTransferController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _techTransferLogic.DeleteTechTransferAsync(id);
        }
    }
}
