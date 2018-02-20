using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Areas.Dev.Models
{
    public class ContractQuery
    {         
        [Display(Name = "合同编号")]
        public string No { get; set; }

        [Display(Name = "合同名称")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
    
}
