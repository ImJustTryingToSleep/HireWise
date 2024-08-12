using HireWise.Common.Entities.UserModels.DB;

namespace HireWise.Common.Entities.QuestionModels.DB
{
    public class Question
    {
        public Guid Id { get; set; }
        public string QuestionName { get; set; }
        public string QuestionBody { get; set; }
        public int Counter { get; set; }
        public bool IsPublished { get; set; } = false;
        public Guid UserId { get; set; }
        public User Author { get; set; }
        public int? GradeLevelId { get; set; }
        public int TechTransferId { get; set; }

    }
}
