using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.ViewModels
{

    public class StaffProjectViewModel
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

        public Guid StaffId { get; set; }


        public Guid ProjectId { get; set; }
    }
}
