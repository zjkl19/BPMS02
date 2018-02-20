using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Areas.Dev.Models
{
    public class ContractListViewModel
    {
        public IEnumerable<ContractViewModel> ContractViewModels { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
