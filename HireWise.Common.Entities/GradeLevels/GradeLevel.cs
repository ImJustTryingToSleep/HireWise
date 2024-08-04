using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.Common.Entities.RecordModels.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.Common.Entities.GradeLevels
{
    public class GradeLevel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public List<Record> Records { get; set; }

    }
}
