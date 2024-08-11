using HireWise.BLL.Logic.Contracts.GradeLevels;
using HireWise.Common.Entities.GradeLevels.DB;
using HireWise.Common.Entities.GradeLevels.InputModels;
using HireWise.DAL.Repository.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.BLL.Logic.GradeLevels
{
    public class GradeLevelLogic : Contracts.GradeLevels.IGradeLevelLogic
    {
        private readonly IGradeLevelRepository _gradeLevelRepository;
        private readonly ILogger<GradeLevelLogic> _logger;

        public GradeLevelLogic(
            IGradeLevelRepository gradeLevelRepository,
            ILogger<GradeLevelLogic> logger)
        {
            _gradeLevelRepository = gradeLevelRepository;
            _logger = logger;
        }

        public async Task CreateGradeAsync(GradeLevelInputModel gradeLevelInputModel)
        {
            try
            {
                var gradeLevel = new GradeLevel
                {
                    Name = gradeLevelInputModel.Name,
                };

                await _gradeLevelRepository.CreateGradeAsync(gradeLevel);
                _logger.LogInformation("Уровень был создан");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании уровня");
            }
            
        }
    }
}
