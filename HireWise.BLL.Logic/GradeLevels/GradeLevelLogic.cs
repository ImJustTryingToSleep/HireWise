using AutoMapper;
using HireWise.BLL.Logic.Contracts.GradeLevels;
using HireWise.Common.Entities.GradeLevels.DB;
using HireWise.Common.Entities.GradeLevels.InputModels;
using HireWise.DAL.Repository.Contracts;
using Microsoft.Extensions.Logging;

namespace HireWise.BLL.Logic.GradeLevels
{
    public class GradeLevelLogic : IGradeLevelLogic
    {
        private readonly IGradeLevelRepository _gradeLevelRepository;
        private readonly ILogger<GradeLevelLogic> _logger;
        private readonly IMapper _mapper;

        public GradeLevelLogic(
            IGradeLevelRepository gradeLevelRepository,
            ILogger<GradeLevelLogic> logger,
            IMapper mapper)
        {
            _gradeLevelRepository = gradeLevelRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateAsync(GradeLevelInputModel gradeLevelInputModel)
        {
            try
            {
                var gradeLevel = _mapper.Map<GradeLevel>(gradeLevelInputModel);
  
                await _gradeLevelRepository.CreateAsync(gradeLevel);
                _logger.LogInformation("Grade Level was crated with Id: {gradeLevel.Id}", gradeLevel.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Grade Level");
            }
            
        }

        public async Task DeleteAsync(int id)
        {
            await _gradeLevelRepository.DeleteAsync(id);
        }

        public IAsyncEnumerable<GradeLevel> GetAsync()
        {
            return _gradeLevelRepository.GetAsync();
        }

        public async Task<GradeLevel> GetAsync(int id)
        {
            return await _gradeLevelRepository.GetAsync(id);
        }

        public async Task UpdateAsync(GradeLevelInputModel gradeLevelInput, int id)
        {
            try
            {
                var gradeLvl = GetAsync(id).Result;

                if (gradeLvl != null)
                {
                    _mapper.Map(gradeLevelInput, gradeLvl);

                    await _gradeLevelRepository.UpdateAsync(gradeLvl);
                    _logger.LogInformation("GradeLevel with Id: {gradeLvl.Id} was updated", gradeLvl.Id);
                }
                else
                {
                    _logger.LogError("There is no GradeLevel with this Id: {id}", id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the GradeLevel");
            }
            
        }
    }
}
