
namespace HireWise.Common.Entities.QuestionModels.InputModels
{
    public class QuestionCreateInputModel
    {
        public string QuestionName { get; set; }
        public string QuestionBody { get; set; }
        public int GradeId { get; set; }
        public int TechTransferId { get; set; }
        public Guid UserId { get; set; }
    }
}
