using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.ViewModels
{

    public class CreateStaffProjectViewModel
    {
        /// <summary>
        /// 指的是StaffProjects表中对应的Id
        /// </summary>
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Display(Name="分工")]
        public Labor Labor { get; set; }

        [Display(Name = "产值比例")]
        public decimal? Ratio { get; set; }

        [Display(Name = "标准产值")]
        [Column(TypeName = "money")]
        public decimal? StandardValue { get; set; }

        [Display(Name = "计算产值")]
        [Column(TypeName = "money")]
        public decimal? CalcValue { get; set; }

        [HiddenInput]
        public Guid StaffId { get; set; }
        [Display(Name = "职工名称")]
        public string StaffName { get; set; }

        [HiddenInput]
        public Guid ProjectId { get; set; }

        [Display(Name = "项目名称")]
        public string ProjectName { get; set; }

        [Display(Name = "项目标准产值")]
        public decimal? ProjectStdValue { get; set; }

        [Display(Name = "项目计算产值")]
        public decimal? ProjectCalcValue { get; set; }
    }
}
