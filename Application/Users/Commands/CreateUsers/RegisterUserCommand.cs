using DomainLayer;
using MediatR;

namespace ApplicationLayer.Users.Commands.CreateUsers
{
    public class RegisterUserCommand : IRequest<OperationResult<string>>
    {
        public string UserName { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}