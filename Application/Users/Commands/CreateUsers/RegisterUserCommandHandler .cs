using ApplicationLayer.Interfaces.IAuthRepository;
using ApplicationLayer.Interfaces.Repositories;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Users.Commands.CreateUsers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IAuthRepository authRepository, IUserRepository userRepository)
        {
            _authRepository = authRepository;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existing = await _userRepository.GetByUsernameAsync(request.UserName);
            if (existing != null)
                throw new Exception("Username already exists");

            var user = new User
            {
                Username = request.UserName,
                Password = request.UserPassword, // Consider hashing in production
                EmailAddress = request.Email,
                Role = "User"
            };

            await _userRepository.AddAsync(user);
            return _authRepository.JWTTokenGenerator(user.Username, user.EmailAddress, user.Role);
        }
    }
    
    
}
