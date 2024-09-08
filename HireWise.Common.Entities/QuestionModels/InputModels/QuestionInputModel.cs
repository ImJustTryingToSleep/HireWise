namespace HireWise.Common.Entities.QuestionModels.InputModels
{
    public class QuestionInputModel
    {
        public string Name { get; set; }
        public string Body { get; set; }
        public int GradeLevelId { get; set; }
        public int TechTransferId { get; set; }
        public Guid UserId { get; set; }
    }
}
