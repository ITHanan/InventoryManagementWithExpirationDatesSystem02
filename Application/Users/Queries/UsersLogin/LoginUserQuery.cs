using ApplicationLayer.ACommen.Users;
using DomainLayer;
using MediatR;

namespace ApplicationLayer.Users.Queries
{
    public class LoginUserQuery : IRequest<OperationResult<string>>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginUserQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
