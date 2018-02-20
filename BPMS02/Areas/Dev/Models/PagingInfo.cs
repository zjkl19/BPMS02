using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Areas.Dev.Models
{
    /// <summary>
    /// 
    /// </summary>
    //《精通ASP.NET MVC5》P153
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "请输入有效的数值")]
        [Required]
        public int ItemsPerPage { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "请输入有效的数值")]
        [Required]
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get
            {
                if (ItemsPerPage == 0)
                {
                    return 0;
                }
                else
                {
                    return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
                }

            }
        }
    }
}
