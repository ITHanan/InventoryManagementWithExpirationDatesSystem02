using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Users.Queries.UsersLogin
{
    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {

            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required...");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required...");


        }
    }
}
