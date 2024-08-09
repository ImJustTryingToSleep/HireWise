using HireWise.Common.Entities.UserModels.DB;

namespace HireWise.Common.Entities.RecordModels.DB
{
    public class Record
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Uri Link { get; set; }
        public int GradeId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public bool IsPublished { get; set; }
    }
}
