using Application.UseCases.Users.Dtos;
using System;

namespace Application.Ports.Secondary
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserById(int userId);
    }
}
