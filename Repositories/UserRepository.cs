using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Models;
using WebApiTemplate.Repositories.Abstract;
using WebApiTemplate.Services.Database;

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

        public async Task<User> InsertUser(User user)
        {
            User newUser = new User
            {
                Username = user.Username,
                Password = new Password
                {
                    Hash = user.Password.Hash
                }
            };
            await _db.Users.AddAsync(newUser);
            await _db.SaveChangesAsync();
            return newUser;
        }
    }
}