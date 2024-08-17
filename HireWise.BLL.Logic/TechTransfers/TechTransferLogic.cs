using AutoMapper;
using HireWise.BLL.Logic.Contracts.ITechTransferLogic;
using HireWise.Common.Entities.TechTransferModels.DB;
using HireWise.Common.Entities.TechTransferModels.InputModels;
using HireWise.DAL.Repository.Contracts;
using Microsoft.Extensions.Logging;

namespace HireWise.BLL.Logic.TechTransfers
{
    public class TechTransferLogic : ITechTransferLogic
    {
        private readonly ITechTransferRepository _techTransferRepository;
        private readonly ILogger<TechTransferLogic> _logger;
        private readonly IMapper _mapper;
        public TechTransferLogic(
            ITechTransferRepository techTransferRepository,
            ILogger<TechTransferLogic> logger,
            IMapper mapper)
        {
            _techTransferRepository = techTransferRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateTechTransferAsync(TechTransferInputModel techTransferInputModel)
        {
            var techTransfer = _mapper.Map<TechTransfer>(techTransferInputModel);

            await _techTransferRepository.CreateTechTransfer(techTransfer);
        }

        public async Task DeleteTechTransferAsync(int id)
        {
            await _techTransferRepository.Delete(id);
        }
    }
}
