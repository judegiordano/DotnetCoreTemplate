using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiTemplate.Dtos.User;
using WebApiTemplate.Models;
using WebApiTemplate.Repositories.Abstract;
using WebApiTemplate.Middleware;
using WebApiTemplate.Services.AuthConsumer;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApiTemplate.Controllers
{
	[ApiController]
	[Router("[controller]")]
	public class UserController : CustomControllerBase
	{
		private readonly IUserRepository _repo;
		private readonly IMapper _mapper;
		public UserController(IUserRepository repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		[SwaggerOperation(
			Summary = "Get User By Id",
			Tags = new[] { "Dev" }
		)]
		[OnlyAllow(AuthConsumers.Consumer.Developer)]
		[HttpGet("id/{id}")]
		public async Task<ActionResult> GetUserById(int id)
		{
			User done = await _repo.GetUserById(id);
			return Ok(_mapper.Map<UserDto>(done));
		}

		[SwaggerOperation(
			Summary = "Get User By Uid",
			Tags = new[] { "Dev" }
		)]
		[OnlyAllow(AuthConsumers.Consumer.Developer)]
		[HttpGet("uid/{uid}")]
		public async Task<ActionResult> GetUserByUid(Guid uid)
		{
			User found = await _repo.GetUserByUId(uid);
			return Ok(_mapper.Map<UserDto>(found));
		}

		[SwaggerOperation(
			Summary = "User Register",
			Tags = new[] { "User" }
		)]
		[OnlyAllow(AuthConsumers.Consumer.ExampleClientA)]
		[HttpPost("register")]
		public async Task<ActionResult> InsertUser(UserCreateDto user)
		{
			User mapped = _mapper.Map<User>(user);
			User inserted = await _repo.InsertUser(mapped);
			UserDto done = _mapper.Map<UserDto>(inserted);
			return Ok(done);
		}

		[SwaggerOperation(
			Summary = "User Login",
			Tags = new[] { "User" }
		)]
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