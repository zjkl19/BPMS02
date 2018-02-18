using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Areas.Dev.Models
{
    public class StaffViewModel
    {


        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Display(Name = "工号")]
        public int No { get; set; }

        [Display(Name = "姓名")]
        [DataType(DataType.Text)]
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

        [Display(Name = "入职日期")]
        [DataType(DataType.Date)]
        public DateTime HiredDate { get; set; }
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

    public enum Education
    {
        [Display(Name = "高中及以下")]
        highSchool = 0,
        [Display(Name = "专科")]
        college = 1,
        [Display(Name = "本科")]
        undergraduate = 2,
        [Display(Name = "研究生")]
        master = 3,
        [Display(Name = "博士")]
        doctor = 4

    }

}
