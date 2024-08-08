using HireWise.Common.Entities.QuestionModels.DB;
using HireWise.Common.Entities.RecordModels.DB;
using System.ComponentModel.DataAnnotations;

namespace HireWise.Common.Entities.GradeLevels
{
    public class GradeLevel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Question>? Questions { get; set; }
        public List<Record>? Records { get; set; }
    }
}
