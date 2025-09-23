using Application.UseCases.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports.Primary
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(int userId);
    }
}
