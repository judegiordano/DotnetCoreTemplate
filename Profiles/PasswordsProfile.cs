using AutoMapper;
using WebApiTemplate.Dtos.Password;
using WebApiTemplate.Models;

namespace WebApiTemplate.Profiles
{
    public class PasswordsProfile : Profile
    {
        public PasswordsProfile()
        {
            CreateMap<Password, PasswordDto>();
            CreateMap<PasswordCreateDto, Password>();
        }
    }
}