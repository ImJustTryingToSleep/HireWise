using FluentValidation;
using HireWise.Common.Entities.RecordModels.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.Common.Entities.ValidationModels
{
    public class RecordValidator : AbstractValidator<RecordInputModel>
    {
        public RecordValidator()
        {
            RuleFor(r => r.Link).NotEmpty();
            RuleFor(r => r.UserId).NotEmpty();
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.TechTransferId).NotEmpty();
            RuleFor(r => r.GradeId).NotEmpty();
        }
    }
}
