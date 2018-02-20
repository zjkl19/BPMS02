using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.ViewModels
{
    public class StaffSelectViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

        [Display(Name = "工号")]
        public int No { get; set; }

        [Display(Name = "姓名")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name = "职位")]
        public Position Position { get; set; }

        [Display(Name = "职称")]
        public JobTitle JobTitle { get; set; }


    }
    public enum Gender
    {
        [Display(Name = "未知")]
        unknown = 0,
        [Display(Name = "男")]
        male = 1,
        [Display(Name = "女")]
        female = 2
    }

    public enum Position
    {
        [Display(Name = "无")]
        none = 0,
        [Display(Name = "室副主任")]
        viceManager = 1,
        [Display(Name = "室主任")]
        manager = 2,
        [Display(Name = "副所长")]
        viceChief = 3,
        [Display(Name = "所长")]
        chief = 4
    }

    public enum JobTitle
    {
        [Display(Name = "无")]
        none = 0,
        [Display(Name = "助理工程师")]
        assistantEngineer = 1,
        [Display(Name = "工程师")]
        engineer = 2,
        [Display(Name = "高级工程师")]
        advanceEngineer = 3,
        [Display(Name = "教授级高工")]
        proAdvEngineer = 4
    }


}
