using FluentValidation;
using HireWise.Common.Entities.QuestionModels.InputModels;

namespace HireWise.Common.Entities.ValidationModels
{
    public class QuestionValidator : AbstractValidator<QuestionInputModel>
    {
        public QuestionValidator()
        {
            RuleFor(q => q.QuestionName).NotEmpty().NotNull();
            RuleFor(q => q.QuestionBody).NotEmpty();
            RuleFor(q => q.GradeLevelId).NotEmpty();
            RuleFor(q => q.TechTransferId).NotEmpty();
        }
    }
}
