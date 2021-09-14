using AutoMapper;
using WebApiTemplate.Dtos.User;
using WebApiTemplate.Models;

namespace WebApiTemplate.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserVerifyDto>();
            CreateMap<UserVerifyDto, User>();
            CreateMap<UserVerifyDto, UserDto>();
            CreateMap<UserDto, UserVerifyDto>();
        }
    }
}