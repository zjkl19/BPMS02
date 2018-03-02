using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.ViewModels
{
    public class CreateProjectInspectionTypeViewModel
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [HiddenInput]
        public Guid ProjectId { get; set; }

        [Display(Name = "项目名称")]
        public string ProjectName { get; set; }

        [HiddenInput]
        public Guid InspectionTypeId { get; set; }

        [Display(Name = "检测类型名称")]
        public string InspectionTypeName { get; set; }

        [Display(Name = "标准产值")]
        [Column(TypeName = "money")]
        public decimal? StandardValue { get; set; }

        [Display(Name = "计算产值")]
        [Column(TypeName = "money")]
        public decimal? CalcValue { get; set; }


    }
}
