using Application.Ports.Secondary;
using Application.UseCases.Users.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Adapters.Secondary
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfigurationProvider _config;

        public UserRepository(ApplicationDbContext context,
            IConfigurationProvider config)
        {
            _context = context;
            _config = config;
        }

        public async Task<UserDto?> GetUserById(int userId)
        {
            return await _context.Users
                .Where(u => u.id == userId)
                .ProjectTo<UserDto>(_config)
                .FirstOrDefaultAsync();
        }
    }
}
