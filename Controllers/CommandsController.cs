using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiTemplate.Dtos.Command;
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

        // POST api/commands
        [HttpPost]
        public async Task<ActionResult> CreateCommand(CommandCreateDto cmd)
        {
            Command model = _mapper.Map<Command>(cmd);
            Command done = await _repo.CreateCommand(model);
            CommandDto mapped = _mapper.Map<CommandDto>(done);

            return CreatedAtAction(nameof(GetCommandById), new { Id = mapped.Id }, mapped);
        }

        // PUT api/commands{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCommand(int id, CommandUpdateDto cmd)
        {
            Command exists = await _repo.GetCommandById(id);
            if(exists == null)
            {
                return NotFound();
            }
            _mapper.Map(cmd, exists);
            await _repo.UpdateCommand(exists);
            return NoContent();
        }
    }
}