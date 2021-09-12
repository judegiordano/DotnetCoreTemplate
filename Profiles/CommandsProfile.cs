using AutoMapper;
using WebApiTemplate.Dtos.Command;
using WebApiTemplate.Models;

namespace WebApiTemplate.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }    
}