using HireWise.BLL.Logic.Contracts.ITechTransferLogic;
using HireWise.Common.Entities.TechTransferModels.DB;
using HireWise.Common.Entities.TechTransferModels.InputModels;
using HireWise.DAL.Repository.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.BLL.Logic.TechTransfers
{
    public class TechTransferLogic : ITechTransferLogic
    {
        private readonly ITechTransferRepository _techTransferRepository;
        private readonly ILogger<TechTransferLogic> _logger;
        public TechTransferLogic(
            ITechTransferRepository techTransferRepository,
            ILogger<TechTransferLogic> logger)
        {
            _techTransferRepository = techTransferRepository;
            _logger = logger;
        }

        public async Task CreateTechTransferAsync(TechTransferInputModel techTransferInputModel)
        {
            var techTransfer = new TechTransfer
            {
                Name = techTransferInputModel.Name,
            };

            await _techTransferRepository.CreateTechTransfer(techTransfer);
        }
    }
}
