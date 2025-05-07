using ApplicationLayer.Interfaces.IAuthRepository;
using ApplicationLayer.Interfaces.Repositories;
using DomainLayer;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Users.Commands.CreateUsers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, OperationResult<string>>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IAuthRepository authRepository, IUserRepository userRepository)
        {
            _authRepository = authRepository;
            _userRepository = userRepository;
        }

        public async Task<OperationResult<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existing = await _userRepository.GetByUsernameAsync(request.UserName);
            if (existing.Data != null)
            {
                return OperationResult<string>.Failure("Username already exists");
            }

            var user = new User
            {
                Username = request.UserName,
                Password = request.UserPassword, // I will Consider hashing in production
                EmailAddress = request.Email,
                Role = "User"
            };

            await _userRepository.AddAsync(user);

            var token = _authRepository.JWTTokenGenerator(user.Username, user.EmailAddress, user.Role);
            return OperationResult<string>.Success(token.Data);
        }

    }


}
