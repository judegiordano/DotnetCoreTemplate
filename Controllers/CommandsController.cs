using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiTemplate.Repositories.Abstract;

namespace WebApiTemplate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepository _repo;

        public CommandsController(ICommandRepository repo)
        {
            _repo = repo;
        }

        // GET api/commands
        [HttpGet]
        public async Task<ActionResult> GetAllCommands()
        {
            var items = await _repo.GetAllCommands();
            return Ok(items);
        }

        // GET api/commands/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCommandById(int id)
        {
            var item = await _repo.GetCommandById(id);
            if (item == null)
            {
                return NotFound(item);
            }
            return Ok(item);
        }
    }
}