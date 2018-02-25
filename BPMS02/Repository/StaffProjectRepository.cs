
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BPMS02.IRepository;
using BPMS02.Models;
using Microsoft.EntityFrameworkCore;

namespace BPMS02.Repository
{
    public class StaffProjectRepository:IStaffProjectRepository
    {
        private DataContext context;

        public StaffProjectRepository(DataContext _context) => context = _context;

        public Task<List<StaffProject>> StaffProjects=> context.StaffProjects.ToListAsync();

        public Task CreateAsync(StaffProject staffProject)
        {
            context.StaffProjects.Add(staffProject);
            return context.SaveChangesAsync();
        }

        public Task<List<StaffProject>> ListAsync() => context.StaffProjects.ToListAsync();


        public Task<StaffProject> QueryByIdAsync(Guid Id) => context.StaffProjects.FindAsync(Id);


        public Task EditAsync(StaffProject staffProject)
        {
            context.Entry(staffProject).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }
        public async Task<StaffProject> Delete(Guid Id)
        {
            var dbEntry = await context.StaffProjects.SingleOrDefaultAsync(m => m.Id == Id);
            if (dbEntry != null)
            {
                context.StaffProjects.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
            return dbEntry;
        }

    }
}