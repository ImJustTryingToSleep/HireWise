using HireWise.Common.Entities.GradeLevels.DB;
using HireWise.Common.Entities.TechTransferModels.DB;
using HireWise.Common.Entities.UserModels.DB;

namespace HireWise.Common.Entities.RecordModels.InputModels
{
    public class RecordInputModel
    {
        public string Name { get; set; }
        public Uri Link { get; set; }
        public GradeLevel? Grade { get; set; }
        public User? User { get; set; }
        public bool IsPublished { get; set; }
        public TechTransfer? TechTransfer { get; set; }
    }
}
