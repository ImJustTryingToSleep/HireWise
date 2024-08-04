using HireWise.Common.Entities.Enums;
using HireWise.Common.Entities.TechTransferModels;
using HireWise.Common.Entities.UserModels.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.Common.Entities.QuestionModels.DB
{
    public class Question
    {
        public Guid Id { get; set; }
        public string QuestionName { get; set; }
        public string QuestionBody { get; set; }
        public int Counter { get; set; }
        public bool IsPublished { get; set; }
        public Guid UserId { get; set; }
        public User Author { get; set; }
        public int GradeId { get; set; }
        public int TechTransferId { get; set; }

    }
}
