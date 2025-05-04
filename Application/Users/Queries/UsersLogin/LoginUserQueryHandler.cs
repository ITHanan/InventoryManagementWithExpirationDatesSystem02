using ApplicationLayer.Interfaces.IAuthRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApplicationLayer.Users.Queries.UsersLogin
{
    internal class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly IAuthRepository _authRepository;

        public LoginUserQueryHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = _authRepository.AuthenticateUser(request.LoginUser.Username, request.LoginUser.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            string token = _authRepository.JWTTokenGenerator(user.Result.Username, user.Result.EmailAddress, user.Result.Role);

            return Task.FromResult(token);
        }
    }
    
    
}
