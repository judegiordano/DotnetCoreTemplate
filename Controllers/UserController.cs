using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiTemplate.Models;
using WebApiTemplate.Repositories.Abstract;
using WebApiTemplate.Middleware;
using WebApiTemplate.Services.AuthConsumer;
using Swashbuckle.AspNetCore.Annotations;
using static WebApiTemplate.Maps.Abstract;

namespace WebApiTemplate.Controllers
{
	[ApiController]
	[Router("[controller]")]
	public class UserController : CustomControllerBase
	{
		private readonly IUserRepository _repo;
		public UserController(IUserRepository repo)
		{
			_repo = repo;
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
			return Ok(done);
			// return Ok(_mapper.Map<UserDto>(done));
		}

		[SwaggerOperation(
			Summary = "Get User By Uid",
			Tags = new[] { "Dev" }
		)]
		[OnlyAllow(AuthConsumers.Consumer.Developer)]
		[HttpGet("uid/{uid}")]
		public async Task<ActionResult> GetUserByUid(Guid uid)
		{
			User found = await _repo.GetUserByUid(uid);
			return Ok(found);
		}

		[SwaggerOperation(
			Summary = "User Register",
			Tags = new[] { "User" }
		)]
		[OnlyAllow(AuthConsumers.Consumer.ExampleClientA)]
		[HttpPost("register")]
		public async Task<ActionResult> InsertUser(Register user)
		{
			User inserted = await _repo.InsertUser(user);
			return Ok(inserted);
		}

		[SwaggerOperation(
			Summary = "User Login",
			Tags = new[] { "User" }
		)]
		[OnlyAllow(AuthConsumers.Consumer.ExampleClientA)]
		[HttpPost("login")]
		public async Task<ActionResult> VerifyUser(Login user)
		{
			User found = await _repo.VerifyUser(user);
			return Ok(found);
		}

		[SwaggerOperation(
			Summary = "Soft Delete User",
			Tags = new[] { "User" }
		)]
		[OnlyAllow(AuthConsumers.Consumer.ExampleClientA)]
		[HttpDelete("delete/{uid}")]
		public async Task<ActionResult> SoftDeleteUser(Guid uid)
		{
			bool deleted = await _repo.DeleteUserByUid(uid);
			return Ok(deleted);
		}
	}
}