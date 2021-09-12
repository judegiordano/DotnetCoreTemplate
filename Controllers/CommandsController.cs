using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiTemplate.Dtos;
using WebApiTemplate.Models;
using WebApiTemplate.Repositories.Abstract;

namespace WebApiTemplate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepository _repo;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET api/commands
        [HttpGet]
        public async Task<ActionResult> GetAllCommands()
        {
            List<Command> items = await _repo.GetAllCommands();
            return Ok(_mapper.Map<List<CommandDto>>(items));
        }

        // GET api/commands/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCommandById(int id)
        {
            Command item = await _repo.GetCommandById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommandDto>(item));
        }
    }
}