using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Areas.Dev.Models
{
    public class StaffListViewModel
    {
        public IEnumerable<StaffViewModel> StaffViewModels { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
