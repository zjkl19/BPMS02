﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPMS02.Models;

namespace BPMS02.IRepository
{
    public interface IContractRepository
    {
        Task CreateAsync(Contract contract);

        Task<List<Contract>> ListAsync();

        Task<Contract> QueryByIdAsync(Guid Id);

        Task<List<Contract>> QueryByNoAsync(string No);

        Task<List<Contract>> QueryByNameAsync(string Name);

        Task EditAsync(Contract staff);

        Task<Contract> DeleteContract(Guid Id);
    }
}
