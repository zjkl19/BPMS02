using BPMS02.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BPMS02.Models;
using Microsoft.EntityFrameworkCore;

namespace BPMS02.Repository
{
    public class StaffRepository:GenericRepository<Staff>,IStaffRepository
    {

        public StaffRepository(DataContext _context):base(_context)
        {
            context = _context;
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

    }
}
