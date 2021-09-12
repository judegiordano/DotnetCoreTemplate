using AutoMapper;
using WebApiTemplate.Dtos;
using WebApiTemplate.Models;

namespace WebApiTemplate.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandDto>();
            CreateMap<CommandCreateDto, Command>();
        }
    }    
}