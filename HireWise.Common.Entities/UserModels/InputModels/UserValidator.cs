using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.Common.Entities.UserModels.InputModels
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
