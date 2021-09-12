using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiTemplate.Models;
using WebApiTemplate.Repositories.Abstract;

namespace WebApiTemplate.Repositories
{
    public class CommandRepository : ICommandRepository
    {
        public async Task<List<Command>> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{ Id = 0, HowTo = "Boil an Egg", Line = "Boil Water", Platform = "Kettle and Pan" },
                new Command{ Id = 1, HowTo = "Cut Bread", Line = "Get a Knife", Platform = "Chopping Board" },
                new Command{ Id = 2, HowTo = "Make Tea", Line = "Place Teabag in Cup", Platform = "Kettle and Cup" },
            };

            return commands;
        }

        public async Task<Command> GetCommandById(int id)
        {
            var commands = new List<Command>
            {
                new Command{ Id = 0, HowTo = "Boil an Egg", Line = "Boil Water", Platform = "Kettle and Pan" },
                new Command{ Id = 1, HowTo = "Cut Bread", Line = "Get a Knife", Platform = "Chopping Board" },
                new Command{ Id = 2, HowTo = "Make Tea", Line = "Place Teabag in Cup", Platform = "Kettle and Cup" },
            };

            var found = commands.Find(a => a.Id == id);
            return found;
        }
    }
}