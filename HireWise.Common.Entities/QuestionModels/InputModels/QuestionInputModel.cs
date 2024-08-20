
namespace HireWise.Common.Entities.QuestionModels.InputModels
{
    public class QuestionInputModel
    {
        public string QuestionName { get; set; }
        public string QuestionBody { get; set; }
        public int GradeLevelId { get; set; }
        public int TechTransferId { get; set; }
        public Guid UserId { get; set; }
    }
}
