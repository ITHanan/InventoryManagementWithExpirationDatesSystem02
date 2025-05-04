using ApplicationLayer.Interfaces.IAuthRepository;
using AutoMapper;
using DomainLayer.Models;
using infrastructureLayer.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _dbContext;

        public AuthRepository(IConfiguration configuration, AppDbContext dbContext)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<User> AuthenticateUser(string username, string password)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                throw new Exception("User not found or invalid credentials");
            }

            return user;
        }

        public string JWTTokenGenerator(string username, string email = "", string role = "Admin")
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException(nameof(username), "Username cannot be null or empty");

            var jwtSettings = _configuration.GetSection("JWT");

            var key = jwtSettings["Key"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expireMinutes = jwtSettings["ExpireMinutes"];

            if (string.IsNullOrWhiteSpace(key) ||
                string.IsNullOrWhiteSpace(issuer) ||
                string.IsNullOrWhiteSpace(audience) ||
                string.IsNullOrWhiteSpace(expireMinutes))
            {
                throw new InvalidOperationException("One or more JWT configuration values are missing in appsettings.json.");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role),
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(expireMinutes)),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

