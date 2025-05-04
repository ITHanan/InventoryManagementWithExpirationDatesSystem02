using DomainLayer.Models;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces.IAuthRepository
{
    public interface IAuthRepository
    {
        Task<User> AuthenticateUser(string username, string password);
        string JWTTokenGenerator(string username, string email = "", string role = "Admin");
    }
}
