using HireWise.Common.Entities.TechTransferModels.DB;

namespace HireWise.DAL.Repository.Contracts
{
    public interface ITechTransferRepository
    {
        Task CreateTechTransfer(TechTransfer techTransfer);
        IAsyncEnumerable<TechTransfer> GetAsync();
        Task<TechTransfer> GetAsync(int id);
        Task Delete(int id);
        Task UpdateAsync(TechTransfer techTransfer);
    }
}
