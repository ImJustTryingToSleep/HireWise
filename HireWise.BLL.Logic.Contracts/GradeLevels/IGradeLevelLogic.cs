using HireWise.Common.Entities.GradeLevels.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.BLL.Logic.Contracts.GradeLevels
{
    public interface IGradeLevelLogic
    {
        Task CreateGradeAsync(GradeLevelInputModel gradeLevelInputModel);
    }
}
