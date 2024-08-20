using HireWise.Common.Entities.GradeLevels.DB;
using HireWise.Common.Entities.TechTransferModels.DB;
using HireWise.DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.DAL.Repository
{
    public class TechTransferRepository : ITechTransferRepository
    {
        private readonly DBContext _dbContext;

        public TechTransferRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTechTransfer(TechTransfer techTransfer)
        {
            await _dbContext.TechTransfers.AddAsync(techTransfer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var techTransfer = await _dbContext.TechTransfers.FirstOrDefaultAsync(t => t.Id == id);
            _dbContext.TechTransfers.Remove(techTransfer);
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

        public async Task UpdateAsync(TechTransfer techTransfer)
        {
            _dbContext.Entry(techTransfer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
