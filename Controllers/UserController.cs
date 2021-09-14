using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiTemplate.Dtos.User;
using WebApiTemplate.Models;
using WebApiTemplate.Repositories.Abstract;
using WebApiTemplate.Middleware;
using WebApiTemplate.Services.AuthConsumer;

namespace WebApiTemplate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public UserController(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [OnlyAllow(AuthConsumers.Consumer.Developer)]
        [HttpGet("{id}")]
        public async Task<ActionResult> InsertUser(int id)
        {
            User inserted = await _repo.GetUserById(id);

            return Ok(_mapper.Map<UserDto>(inserted));
        }

        [OnlyAllow(AuthConsumers.Consumer.ExampleClientA)]
        [HttpPost("register")]
        public async Task<ActionResult> InsertUser(UserCreateDto user)
        {
            User mapped = _mapper.Map<User>(user);
            User inserted = await _repo.InsertUser(mapped);
            UserDto done = _mapper.Map<UserDto>(inserted);
            return Ok(done);
        }

        [OnlyAllow(AuthConsumers.Consumer.ExampleClientA)]
        [HttpPost("login")]
        public async Task<ActionResult> VerifyUser(UserVerifyDto user)
        {
            User mapped = _mapper.Map<User>(user);
            User found = await _repo.VerifyUser(mapped);
            UserDto done = _mapper.Map<UserDto>(found);
            return Ok(done);
        }
    }
}