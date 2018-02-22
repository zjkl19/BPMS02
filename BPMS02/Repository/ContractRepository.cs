
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPMS02.Models;
using BPMS02.IRepository;

namespace BPMS02.Repository
{
    public class ContractRepository:IContractRepository
    {
        private DataContext context;

        public Task<List<Contract>> Contracts
        {
            get
            {
                return context.Contracts.ToListAsync();
            }
        }
        public ContractRepository(DataContext _context)
        {
            context = _context;
        }

        public Task CreateAsync(Contract contract)
        {
            context.Contracts.Add(contract);
            return context.SaveChangesAsync();
        }

        public Task<List<Contract>> ListAsync()
        {
            return context.Contracts.ToListAsync();
        }

        public Task<Contract> QueryByIdAsync(Guid Id)
        {
            return context.Contracts.FindAsync(Id);
        }

        public Task<List<Contract>> QueryByNoAsync(string No)
        {
            return context.Contracts.Where(p => p.No == No).ToListAsync();
        }

        public Task<List<Contract>> QueryByNameAsync(string Name)
        {

            return context.Contracts.Where(p => p.Name.Contains(Name)).ToListAsync();
        }

        public Task EditAsync(Contract contract)
        {
            context.Entry(contract).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }

        public async Task<Contract> DeleteContract(Guid Id)
        {
            var dbEntry = await context.Contracts.SingleOrDefaultAsync(m => m.Id == Id);
            if (dbEntry != null)
            {
                context.Contracts.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
            return dbEntry;
        }

    }
}
