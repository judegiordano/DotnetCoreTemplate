using System.Threading.Tasks;
using WebApiTemplate.Models;

namespace WebApiTemplate.Repositories.Abstract
{
    public interface IUserRepository
    {
        Task<User> InsertUser(User user);
        Task<User> GetUserById(int id);
    }
}