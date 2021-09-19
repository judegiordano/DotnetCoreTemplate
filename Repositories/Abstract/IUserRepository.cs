using System;
using System.Threading.Tasks;
using WebApiTemplate.Models;
using static WebApiTemplate.Maps.Abstract;

namespace WebApiTemplate.Repositories.Abstract
{
	public interface IUserRepository
	{
		Task<User> InsertUser(Register user);
		Task<User> GetUserById(int id);
		Task<User> GetUserByUid(Guid uid);
		Task<bool> DeleteUserByUid(Guid uid);
		Task<User> VerifyUser(Login user);
	}
}