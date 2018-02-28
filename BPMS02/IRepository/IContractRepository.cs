﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPMS02.Models;

namespace BPMS02.IRepository
{
    public interface IContractRepository:IBasicCRUDRepository<Contract>
    {
        Task<List<Contract>> QueryByNoAsync(string No);

        Task<List<Contract>> QueryByNameAsync(string Name);

    }
}
