using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.Common.Entities.RecordModels.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.Common.Entities.TechTransferModels
{
    public class TechTransfer
    {
        public int Id { get; set; }
        public string TechTransferName { get; set; }
        public List<Question> Questions { get; set; } 
        public List<Record> Records { get; set; }
    }
}
