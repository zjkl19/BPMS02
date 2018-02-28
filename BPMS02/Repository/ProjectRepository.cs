using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BPMS02.IRepository;
using BPMS02.Models;
using Microsoft.EntityFrameworkCore;

namespace BPMS02.Repository
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DataContext _context) : base(_context)
        {
            context = _context;
        }

        public Task<List<Project>> QueryByNameAsync(string Name)
        {

            return context.Projects.Where(p => p.Name.Contains(Name)).ToListAsync();
        }

    }
}
