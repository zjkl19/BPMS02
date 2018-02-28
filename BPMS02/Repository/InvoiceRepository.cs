
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPMS02.IRepository;
using BPMS02.Models;

namespace BPMS02.Repository
{
    public class InvoiceRepository:IInvoicesRepository
    {
        private DataContext context;

        public InvoiceRepository(DataContext _context)
        {
            context = _context;
        }

    }
}
