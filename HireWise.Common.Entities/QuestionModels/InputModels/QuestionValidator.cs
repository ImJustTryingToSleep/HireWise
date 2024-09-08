using FluentValidation;

namespace HireWise.Common.Entities.QuestionModels.InputModels
{
    public class QuestionValidator : AbstractValidator<QuestionInputModel>
    {
        public QuestionValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
            RuleFor(q => q.Body).NotEmpty();
            RuleFor(q => q.GradeLevelId).NotEmpty();
            RuleFor(q => q.TechTransferId).NotEmpty();
        }
    }
}
