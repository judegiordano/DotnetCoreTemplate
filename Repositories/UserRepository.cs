using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Models;
using WebApiTemplate.Repositories.Abstract;
using WebApiTemplate.Services.Database;
using WebApiTemplate.Services.PasswordService;

namespace WebApiTemplate.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _db;

        public UserRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _db.Users
                .Include(a => a.Password)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByUId(Guid uid)
        {
            return await _db.Users
                .Include(a => a.Password)
                .FirstOrDefaultAsync(u => u.Uid == uid);
        }

        public async Task<User> InsertUser(User user)
        {
            User newUser = new User
            {
                Username = user.Username,
                Password = new Password
                {
                    Hash = PasswordService.HashPassword(user.Password.Hash)
                }
            };
            await _db.Users.AddAsync(newUser);
            await _db.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> VerifyUser(User user)
        {
            User exists = await _db.Users
                .Include(a => a.Password)
                .FirstOrDefaultAsync(u => u.Username == user.Username);

            bool match = PasswordService.VerifyHash(user.Password.Hash, exists.Password.Hash);
            if (!match) throw new ApplicationException("invalid login");

            return exists;
        }
    }
}