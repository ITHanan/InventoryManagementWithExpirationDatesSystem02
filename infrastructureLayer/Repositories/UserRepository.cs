using ApplicationLayer.ACommen.DTOs;
using ApplicationLayer.Interfaces.Repositories;
using AutoMapper;
using DomainLayer;
using DomainLayer.Models;
using infrastructureLayer.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<OperationResult<UserDto>> GetByUsernameAsync(string username)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
                return OperationResult<UserDto>.Failure("User not found.");

            var dto = _mapper.Map<UserDto>(user);
            return OperationResult<UserDto>.Success(dto);
        }

        public async Task<OperationResult<bool>> AddAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return OperationResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Failure($"Failed to add user: {ex.Message}");
            }
        }



        public async Task<OperationResult<List<UserDto>>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            var userDtos = _mapper.Map<List<UserDto>>(users);
            return OperationResult<List<UserDto>>.Success(userDtos);
        }
      
    }
}
