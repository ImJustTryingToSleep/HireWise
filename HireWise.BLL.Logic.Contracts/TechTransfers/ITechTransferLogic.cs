using HireWise.Common.Entities.TechTransferModels.DB;
using HireWise.Common.Entities.TechTransferModels.InputModels;

namespace HireWise.BLL.Logic.Contracts.TechTransfers
{
    public interface ITechTransferLogic
    {
        Task CreateAsync(TechTransferInputModel techTransferInputModel);
        IAsyncEnumerable<TechTransfer> GetAsync();
        Task<TechTransfer> GetAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(TechTransferInputModel model, int id);
    }
}
