using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Models
{
    /// <summary>
    /// 检测类型
    /// </summary>
    public class InspectionType
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 检测类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 1种检测类型可以在n个项目中使用
        /// </summary>
        public virtual ICollection<ProjectInspectionType> ProjectInspectionTypes { get; set; }
    }
}
