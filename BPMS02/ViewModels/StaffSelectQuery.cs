using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.ViewModels
{
    public class StaffSelectQuery
    {
        [Display(Name = "工号")]
        public int No { get; set; }

        [Display(Name = "姓名")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
