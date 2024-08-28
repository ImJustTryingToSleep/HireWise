using HireWise.Common.Entities.TechTransferModels.DB;
using HireWise.DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HireWise.DAL.Repository
{
    public class TechTransferRepository : ITechTransferRepository
    {
        private readonly HireWiseDBContext _dbContext;

        public TechTransferRepository(HireWiseDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTechTransfer(TechTransfer techTransfer)
        {
            await _dbContext.TechTransfers.AddAsync(techTransfer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TechTransfer>> GetAsync()
        {
            return await _dbContext.TechTransfers.ToListAsync();
        }

        public async Task<TechTransfer> GetAsync(int id)
        {
            return await _dbContext.TechTransfers.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task Delete(int id)
        {
            var techTransfer = await _dbContext.TechTransfers.FirstOrDefaultAsync(t => t.Id == id);
            _dbContext.TechTransfers.Remove(techTransfer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TechTransfer techTransfer)
        {
            _dbContext.Entry(techTransfer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
