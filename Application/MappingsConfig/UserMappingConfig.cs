using Application.UseCases.Users.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingsConfig
{
    public class UserMappingConfig : Profile
    {
        public UserMappingConfig()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();     
        }
    }
}
