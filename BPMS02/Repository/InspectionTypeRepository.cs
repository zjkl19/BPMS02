
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPMS02.IRepository;
using BPMS02.Models;
namespace BPMS02.Repository
{
    public class InspectionTypeRepository:GenericRepository<InspectionType>, IInspectionTypeRepository
    {
        public InspectionTypeRepository(DataContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
