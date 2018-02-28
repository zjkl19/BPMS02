
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPMS02.IRepository;
using BPMS02.Models;
using Microsoft.EntityFrameworkCore;

namespace BPMS02.Repository
{
    public class BridgeRepository : GenericRepository<Bridge>, IBridgeRepository
    {
        public BridgeRepository(DataContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<List<Bridge>> QueryByNameAsync(string Name)
        {
            return await context.Bridges.Where(p => p.Name.Contains(Name)).ToListAsync();
        }

    }
}
