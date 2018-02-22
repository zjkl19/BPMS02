using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BPMS02.IRepository;
using BPMS02.Models;
using Microsoft.EntityFrameworkCore;

namespace BPMS02.Repository
{
    public class ProjectRepository:IProjectRepository
    {
        private DataContext context;

        public ProjectRepository(DataContext _context)
        {
            context = _context;
        }

        public Task<List<Project>> Projects
        {
            get
            {
                return context.Projects.ToListAsync();
            }
        }


        public Task CreateAsync(Project project)
        {
            context.Projects.Add(project);
            return context.SaveChangesAsync();
        }

        public Task<List<Project>> ListAsync()
        {
            return context.Projects.ToListAsync();
        }

        public Task<Project> QueryByIdAsync(Guid Id)
        {
            return context.Projects.FindAsync(Id);
        }


        public Task<List<Project>> QueryByNameAsync(string Name)
        {

            return context.Projects.Where(p => p.Name.Contains(Name)).ToListAsync();
        }

        public Task EditAsync(Project project)
        {
            context.Entry(project).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }

        public async Task<Project> Delete(Guid Id)
        {
            var dbEntry = await context.Projects.SingleOrDefaultAsync(m => m.Id == Id);
            if (dbEntry != null)
            {
                context.Projects.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
            return dbEntry;
        }
    }
}
