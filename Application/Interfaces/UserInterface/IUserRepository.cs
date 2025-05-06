using ApplicationLayer.ACommen.DTOs;
using DomainLayer;
using DomainLayer.Models;

namespace ApplicationLayer.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<OperationResult<UserDto>> GetByUsernameAsync(string username);
        Task<OperationResult<bool>> AddAsync(User user);
        Task<OperationResult<List<UserDto>>> GetAllAsync();
    }
}