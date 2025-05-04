using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Users.Commands.CreateUsers
{
    public class RegisterUserCommand : IRequest<string>
    {
        public string UserName { get; set; } = string.Empty;           

        public string UserPassword { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
    
    
}
