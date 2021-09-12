using AutoMapper;
using WebApiTemplate.Dtos;
using WebApiTemplate.Models;

namespace WebApiTemplate.Profiles
{
    class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandDto>();
        }
    }    
}