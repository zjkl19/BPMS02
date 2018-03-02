using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.ViewModels
{
    public class InspectionTypeSelectViewModel
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Display(Name="检测类型代码")]
        public int Type { get; set; }

        [Display(Name = "检测类型名称")]
        public string Name { get; set; }

        [Display(Name = "检测类型描述")]
        public string Description { get; set; }
    }
}
