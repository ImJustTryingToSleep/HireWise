﻿using HireWise.Common.Entities.TechTransferModels.DB;
using HireWise.DAL.Repository.Contracts;
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
    }
}
