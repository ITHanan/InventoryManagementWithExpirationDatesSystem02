using ApplicationLayer.Interfaces.IAuthRepository;
using ApplicationLayer.Users.Queries;
using ApplicationLayer.Users.Queries.UsersLogin;
using DomainLayer;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationLayer.Users.Handlers
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, OperationResult<string>>
    {
        private readonly IAuthRepository _authRepository;

        public LoginUserQueryHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<OperationResult<string>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
           
                var user = await _authRepository.AuthenticateUser(request.Username, request.Password);

                if (!user.IsSuccess|| user.Data == null)
                {
                    return OperationResult<string>.Failure(user.ErrorMessage ?? "Invalid username or password.");
                }


              

                var token = _authRepository.JWTTokenGenerator(user.Data.Username, user.Data.EmailAddress, user.Data.Role);

                if (!token.IsSuccess)
                {

                   return OperationResult<string>.Failure(token.ErrorMessage ?? "Failed to generate Token");

                }

                return OperationResult<string>.Success(token.Data);
         
            
                
            
        }
    }
}

