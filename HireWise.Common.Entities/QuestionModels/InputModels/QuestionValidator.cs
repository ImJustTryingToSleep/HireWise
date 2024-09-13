using FluentValidation;

namespace HireWise.Common.Entities.QuestionModels.InputModels
{
    public class QuestionValidator : AbstractValidator<QuestionInputModel>
    {
        public QuestionValidator()
        {
            RuleFor(q => q.QuestionName).NotEmpty();
            RuleFor(q => q.QuestionBody).NotEmpty();
            RuleFor(q => q.GradeLevelId).NotEmpty();
            RuleFor(q => q.TechTransferId).NotEmpty();
        }
    }
}
