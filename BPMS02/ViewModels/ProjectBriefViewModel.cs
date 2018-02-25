using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.ViewModels
{
    public class ProjectBriefViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

        [Display(Name = "项目名称")]
        public string Name { get; set; }

        [Display(Name = "关联桥梁")]
        public string BridgeName { get; set; }
    }
}
