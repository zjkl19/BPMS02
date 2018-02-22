using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Areas.Dev.Models
{
    public class BridgeListViewModel
    {
        public IEnumerable<BridgeViewModel> BridgeViewModels { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
