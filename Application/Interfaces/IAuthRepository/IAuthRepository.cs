using DomainLayer.Models;
using DomainLayer;

namespace ApplicationLayer.Interfaces.IAuthRepository
{
    public interface IAuthRepository
    {
        Task<OperationResult<User>> AuthenticateUser(string username, string password);
        OperationResult<string> JWTTokenGenerator(string username, string email = "", string role = "Admin");
    }
}
