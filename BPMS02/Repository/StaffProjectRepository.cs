
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BPMS02.IRepository;
using BPMS02.Models;
using Microsoft.EntityFrameworkCore;

namespace BPMS02.Repository
{
    public class StaffProjectRepository: GenericRepository<StaffProject>, IStaffProjectRepository
    {   
        public StaffProjectRepository(DataContext _context):base(_context) => context = _context;

    }
}