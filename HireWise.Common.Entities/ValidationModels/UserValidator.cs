using FluentValidation;
using HireWise.Common.Entities.UserModels.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.Common.Entities.ValidationModels
{
    public class UserValidator : AbstractValidator<UserInputModel>
    {
        public UserValidator()
        {
            RuleFor(u => u.Login).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();
        }
    }
}
