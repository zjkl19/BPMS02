using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPMS02.Areas.Dev.Models
{
    public class CreateBridgeViewModel
    {      
        [MaxLength(100)]
        [Display(Name = "桥梁名称")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "桥梁长度")]
        public double Length { get; set; }

        [Required]
        [Display(Name = "桥梁宽度")]
        public double Width { get; set; }

        [Required]
        [Display(Name = "桥梁跨数")]
        public int SpanNumber { get; set; }

        [Required]
        [Display(Name = "桥梁结构形式")]
        public StructureType StructureType { get; set; }

        [MaxLength(200)]
        [Display(Name = "备注")]
        public string Comment { get; set; }

    }

}
