using HireWise.Common.Entities.TechTransferModels.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.BLL.Logic.Contracts.ITechTransferLogic
{
    public interface ITechTransferLogic
    {
        Task CreateTechTransferAsync(TechTransferInputModel techTransferInputModel);
    }
}
