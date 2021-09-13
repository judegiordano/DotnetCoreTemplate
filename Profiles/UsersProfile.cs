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
        }
    }
}