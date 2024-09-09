using HireWise.Common.Entities.GradeLevels.DB;
using HireWise.Common.Entities.TechTransferModels.DB;
using HireWise.Common.Entities.UserModels.DB;

namespace HireWise.Common.Entities.RecordModels.InputModels
{
    public class RecordInputModel
    {
        public string Name { get; set; }
        public Uri Link { get; set; }
        public int GradeId { get; set; }
        public Guid UserId { get; set; }
        public bool IsPublished { get; set; }
        public int TechTransferId { get; set; }
    }
}
