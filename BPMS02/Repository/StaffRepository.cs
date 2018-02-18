using BPMS02.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BPMS02.Models;
using Microsoft.EntityFrameworkCore;

namespace BPMS02.Repository
{
    public class StaffRepository:IStaffRepository
    {
        private DataContext context;
        public StaffRepository(DataContext _context)
        {
            context = _context;
        }

        public IEnumerable<Staff> QueryByNo(int No)
        {
            return context.Staffs.Where(p => p.No == No);
        }

        public Task CreateAsync(Staff staff)
        {
            context.Staffs.Add(staff);
            return context.SaveChangesAsync();
        }

        public Task<List<Staff>> Staffs
        {
            get
            {
                return context.Staffs.ToListAsync();
            }
        }

        public Task<List<Staff>> ListAsync()
        {
            return context.Staffs.ToListAsync();
        }

        public Task<Staff> QueryByIdAsync(Guid Id)
        {
            //return context.Staffs.Where(p => p.Id == Id).FirstOrDefaultAsync();
            return context.Staffs.FindAsync(Id);
        }

        public Task<List<Staff>> QueryByNoAsync(int? No)
        {
            //int _currentPage = No.HasValue ? No : null;
            return context.Staffs.Where(p=>p.No==No).ToListAsync();
        }

        public Task<List<Staff>> QueryByNameAsync(string Name)
        {

            return context.Staffs.Where(p => p.Name.Contains(Name)).ToListAsync();
        }

        public Task EditAsync(Staff staff)
        {
            context.Entry(staff).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }

        public async Task<Staff> DeleteStaff(Guid Id)
        {
            var dbEntry =await context.Staffs.SingleOrDefaultAsync(m => m.Id == Id);
            if (dbEntry!=null)
            {
                context.Staffs.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
            return dbEntry;
        }
    }
}
