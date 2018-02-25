using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BPMS02.IRepository;
using BPMS02.Models;
using Microsoft.EntityFrameworkCore;

namespace BPMS02.Repository
{
    public class BridgeRepository: IBridgeRepository
    {
        private DataContext context;

        public BridgeRepository(DataContext _context)
        {
            context = _context;
        }

        public Task<List<Bridge>> Bridges => context.Bridges.ToListAsync();


        public Task CreateAsync(Bridge bridge)
        {
            context.Bridges.Add(bridge);
            return context.SaveChangesAsync();
        }

        public Task<List<Bridge>> ListAsync()
        {
            return context.Bridges.ToListAsync();
        }

        public Task<Bridge> QueryByIdAsync(Guid Id)
        {
            return context.Bridges.FindAsync(Id);
        }


        public Task<List<Bridge>> QueryByNameAsync(string Name)
        {

            return context.Bridges.Where(p => p.Name.Contains(Name)).ToListAsync();
        }

        public Task EditAsync(Bridge bridge)
        {
            context.Entry(bridge).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }

        public async Task<Bridge> Delete(Guid Id)
        {
            var dbEntry = await context.Bridges.SingleOrDefaultAsync(m => m.Id == Id);
            if (dbEntry != null)
            {
                context.Bridges.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
            return dbEntry;
        }
    }
}
