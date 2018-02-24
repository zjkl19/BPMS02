using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Models
{
    /// <summary>
    /// 职工-项目关联表
    /// </summary>
    public class StaffProject
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 分工
        /// </summary>
        public int Labor { get; set; }

        /// <summary>
        /// 产值比例
        /// </summary>
        public decimal? Ratio { get; set; }

        /// <summary>
        /// 标准产值
        /// </summary>
        [Column(TypeName = "money")]
        public decimal? StandardValue { get; set; }

        /// <summary>
        /// 计算产值
        /// </summary>
        [Column(TypeName = "money")]
        public decimal? CalcValue { get; set; }

        [ForeignKey("Staff")]
        public Guid StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }


    }
}
