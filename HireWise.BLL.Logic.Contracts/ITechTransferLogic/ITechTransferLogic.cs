using HireWise.Common.Entities.TechTransferModels.DB;
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
        Task DeleteTechTransferAsync(int id);
        Task<List<TechTransfer>> GetAsync();
        Task<TechTransfer> GetAsync(int id);
        Task UpdateAsync(TechTransferInputModel model, int id);
    }
}
