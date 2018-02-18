using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Areas.Dev.Models
{
    public class EditStaffViewModel
    {

        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Display(Name = "工号")]
        public int No { get; set; }

        [Required(ErrorMessage = "请输入{0}.")]
        [StringLength(50, ErrorMessage = "最大长度不超过50")]
        [DataType(DataType.Text)]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Display(Name = "性别")]
        public Gender Gender { get; set; }

        [Display(Name = "办公电话")]
        public string OfficePhone { get; set; }

        [Display(Name = "移动电话")]
        public string MobilePhone { get; set; }

        [Display(Name = "职位")]
        public Position Position { get; set; }

        [Display(Name = "职称")]
        public JobTitle JobTitle { get; set; }

        [Display(Name = "学历")]
        public Education Education { get; set; }

        [Required(ErrorMessage = "请输入入职日期.")]
        [Display(Name = "入职日期")]
        public DateTime HiredDate { get; set; }

    }



}

