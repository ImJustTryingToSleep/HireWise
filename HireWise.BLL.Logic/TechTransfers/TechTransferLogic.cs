using AutoMapper;
using HireWise.BLL.Logic.Contracts.ITechTransferLogic;
using HireWise.Common.Entities.GradeLevels.DB;
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

        public async Task<List<TechTransfer>> GetAsync()
        {
            return await _techTransferRepository.GetAsync();
        }

        public async Task<TechTransfer> GetAsync(int id)
        {
            return await _techTransferRepository.GetAsync(id);
        }

        public async Task UpdateAsync(TechTransferInputModel model, int id)
        {
            var techTransfer = GetAsync(id).Result;

            try
            {
                if (techTransfer != null)
                {
                    _mapper.Map(model, techTransfer);

                    await _techTransferRepository.UpdateAsync(techTransfer);
                    _logger.LogInformation("Tech Transfer with Id: {techTransfer.Id} was updated", techTransfer.Id);
                }
                else
                {
                    _logger.LogError("There is no Tech Transfer with this Id: {id}", id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the TechTransfer");
            }
            
        }
    }
}
