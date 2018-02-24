using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.ViewModels
{
    public class ContractSelectViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

        [Display(Name = "合同编号")]
        public string No { get; set; }

        [Display(Name = "合同名称")]
        public string Name { get; set; }

        [Display(Name = "合同负责人")]
        public string ResponseStaffName { get; set; }

    }
}
