using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.ViewModels
{
    public class StaffSelectListViewModel
    {
        public IEnumerable<StaffSelectViewModel> StaffSelectViewModels { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
