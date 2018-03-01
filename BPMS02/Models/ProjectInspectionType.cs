using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Models
{
    /// <summary>
    /// 项目-检测类型
    /// </summary>
    public class ProjectInspectionType
    {
        public Guid Id { get; set; }

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

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [ForeignKey("InspectionType")]
        public Guid InspectionTypeId { get; set; }
        public virtual InspectionType InspectionType { get; set; }
    }
}
