using Application.Ports.Primary;
using Application.Ports.Secondary;
using Application.UseCases.Users.Dtos;
using System;

namespace Infrastructure.Adapters.Primary
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserDto> GetUserById(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user is null)
                throw new Exception("User not found");
            return user;
        }
    }
}
