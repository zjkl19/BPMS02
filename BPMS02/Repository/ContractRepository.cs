
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPMS02.Models;
using BPMS02.IRepository;

namespace BPMS02.Repository
{
    public class ContractRepository:GenericRepository<Contract>,IContractRepository
    {
        public ContractRepository(DataContext _context) : base(_context)
        {
            context = _context;
        }

        public Task<List<Contract>> QueryByNoAsync(string No)
        {
            return context.Contracts.Where(p => p.No == No).ToListAsync();
        }

        public Task<List<Contract>> QueryByNameAsync(string Name)
        {
            return context.Contracts.Where(p => p.Name.Contains(Name)).ToListAsync();
        }


    }
}
