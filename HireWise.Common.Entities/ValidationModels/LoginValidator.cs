using FluentValidation;
using HireWise.Common.Entities.LoginModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireWise.Common.Entities.ValidationModels
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator() 
        {
            RuleFor(lv => lv.Email).NotEmpty();
            RuleFor(lv => lv.Password).NotEmpty();
        }
    }
}
