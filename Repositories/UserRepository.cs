using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Models;
using WebApiTemplate.Repositories.Abstract;
using WebApiTemplate.Services.Database;
using WebApiTemplate.Services.PasswordService;
using static WebApiTemplate.Maps.Abstract;

namespace WebApiTemplate.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly DatabaseContext _db;

		public UserRepository(DatabaseContext db)
		{
			_db = db;
		}

		public async Task<bool> DeleteUserByUid(Guid uid)
		{
			User found = await _db.Users
				.Include(a => a.Password)
				.Where(u =>
					u.Uid == uid &&
					!u.IsDeleted)
				.FirstOrDefaultAsync();

			if (found == null) throw new ApplicationException("user not found");

			found.IsDeleted = true;
			await _db.SaveChangesAsync();
			return true;
		}

		public async Task<User> GetUserById(int id)
		{
			return await _db.Users
				.Include(a => a.Password)
				.Where(u =>
					u.Id == id &&
					!u.IsDeleted)
				.FirstOrDefaultAsync();
		}

		public async Task<User> GetUserByUid(Guid uid)
		{
			return await _db.Users
				.Include(a => a.Password)
				.Where(u =>
					u.Uid == uid &&
					!u.IsDeleted)
				.FirstOrDefaultAsync();
		}

		public async Task<User> InsertUser(Register user)
		{
			User exists = await _db.Users
				.Where(u => u.Username == user.Username || u.Email == user.Email)
				.FirstOrDefaultAsync();

			if (exists != null) throw new ApplicationException("username / email taken");

			User newUser = new User
			{
				Username = user.Username,
				Email = user.Email,
				Password = new Password
				{
					Hash = PasswordService.HashPassword(user.Password)
				}
			};
			await _db.Users.AddAsync(newUser);
			await _db.SaveChangesAsync();
			return newUser;
		}

		public async Task<User> VerifyUser(Login user)
		{
			User exists = await _db.Users
				.Include(a => a.Password)
				.Where(u =>
					u.Username == user.Username &&
					!u.IsDeleted)
				.FirstOrDefaultAsync();
			if (exists == null) throw new ApplicationException("username not found");

			bool match = PasswordService.VerifyHash(user.Password, exists.Password.Hash);
			if (!match) throw new ApplicationException("incorrect password");

			return exists;
		}
	}
}