using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiTemplate.Models;

namespace WebApiTemplate.Repositories.Abstract
{
    public interface ICommandRepository
    {
        Task<List<Command>> GetAllCommands();
        Task<Command> GetCommandById(int id);
        Task<Command> CreateCommand(Command cmd);
        Task<bool> UpdateCommand(Command cmd);
        Task<bool> DeleteCommand(Command cmd);
    }
}