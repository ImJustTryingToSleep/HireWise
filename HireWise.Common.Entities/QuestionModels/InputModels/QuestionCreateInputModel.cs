using HireWise.Common.Entities.Enums;
using HireWise.Common.Entities.TechTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.Common.Entities.QuestionModels.InputModels
{
    public class QuestionCreateInputModel
    {
        public string QuestionName { get; set; }
        public string QuestionBody { get; set; }
        public int GradeId { get; set; }
        public int TechTransferId { get; set; }
    }
}
