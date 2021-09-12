using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Database;
using WebApiTemplate.Models;
using WebApiTemplate.Repositories.Abstract;

namespace WebApiTemplate.Repositories
{
    public class CommandRepository : ICommandRepository
    {
        private readonly DatabaseContext _db;
        
        public CommandRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<Command> CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            await _db.Commands.AddAsync(cmd);
            await _db.SaveChangesAsync();
            return cmd;
        }

        public async Task<List<Command>> GetAllCommands()
        {
            return await _db.Commands.ToListAsync();
        }

        public async Task<Command> GetCommandById(int id)
        {
            return await _db.Commands.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}