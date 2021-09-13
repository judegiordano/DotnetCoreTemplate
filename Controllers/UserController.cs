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

        [HttpPut]
        public async Task<ActionResult> InsertUser(UserCreateDto user)
        {
            User mapped = _mapper.Map<User>(user);
            User inserted = await _repo.InsertUser(mapped);
            UserDto done = _mapper.Map<UserDto>(inserted);
            return Ok(done);
        }
    }
}