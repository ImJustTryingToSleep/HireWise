using HireWise.Common.Entities.TechTransferModels.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.DAL.Repository.Contracts
{
    public interface ITechTransferRepository
    {
        Task CreateTechTransfer(TechTransfer techTransfer);
    }
}
