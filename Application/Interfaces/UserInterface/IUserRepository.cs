using DomainLayer.Models;

namespace ApplicationLayer.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task AddAsync(User user);
        Task<List<User>> GetAllAsync();
    }
}