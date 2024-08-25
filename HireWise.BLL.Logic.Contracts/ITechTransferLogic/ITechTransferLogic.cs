using HireWise.Common.Entities.TechTransferModels.DB;
using HireWise.Common.Entities.TechTransferModels.InputModels;

namespace HireWise.BLL.Logic.Contracts.ITechTransferLogic
{
    public interface ITechTransferLogic
    {
        Task CreateAsync(TechTransferInputModel techTransferInputModel);
        Task<List<TechTransfer>> GetAsync();
        Task<TechTransfer> GetAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(TechTransferInputModel model, int id);
    }
}
