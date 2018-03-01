using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPMS02.ViewModels
{
    public class BridgeSelectViewModel
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

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
    public enum StructureType:int
    {
        [Display(Name = "简支梁、板桥")]
        SimpleSupportedBeam = 1,
        [Display(Name = "石拱桥、圬工拱桥")]
        Arch = 2,
        [Display(Name = "连续梁桥、连续刚构桥")]
        Continous_Rigid_Beam = 3,
        [Display(Name = "钢管混凝土拱桥、钢筋混凝土拱桥")]
        CFST_RC = 4,
        [Display(Name = "悬索桥、斜拉桥")]
        Suspension_CableStayed = 5,
    }
}

