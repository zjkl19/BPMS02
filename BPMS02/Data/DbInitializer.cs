using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPMS02.Areas.Dev.Models;
using BPMS02.Models;

namespace BPMS02.Data
{
    public static class DbInitializer
    {
        //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Staffs.Any())
            {
                return;   // DB has been seeded
            }

            var staffs = new Staff[]
            {

                new Staff{
                    Id=Guid.NewGuid(),
                    No=1743,
                    Name="林迪南",
                    Gender=Convert.ToInt32(Gender.male),
                    OfficePhone="1",
                    MobilePhone="1",
                    Position=Convert.ToInt32(Position.none),
                    JobTitle=Convert.ToInt32(JobTitle.assistantEngineer),
                    Education=Convert.ToInt32(Education.master),
                    HiredDate=DateTime.Parse("2016-01-20")
                },
                new Staff{
                    Id=Guid.NewGuid(),
                    No=510,
                    Name="邵顺安",
                    Gender=Convert.ToInt32(Gender.male),
                    OfficePhone="1",
                    MobilePhone="1",
                    Position=Convert.ToInt32(Position.viceManager),
                    JobTitle=Convert.ToInt32(JobTitle.advanceEngineer),
                    Education=Convert.ToInt32(Education.master),
                    HiredDate=DateTime.Parse("2009-01-20")
                },
                new Staff{
                    Id=Guid.NewGuid(),
                    No=528,
                    Name="李鹏",
                    Gender=Convert.ToInt32(Gender.male),
                    OfficePhone="1",
                    MobilePhone="1",
                    Position=Convert.ToInt32(Position.viceManager),
                    JobTitle=Convert.ToInt32(JobTitle.engineer),
                    Education=Convert.ToInt32(Education.master),
                    HiredDate=DateTime.Parse("2009-01-20")
                },
                new Staff{
                    Id=Guid.NewGuid(),
                    No=1096,
                    Name="刘明",
                    Gender=Convert.ToInt32(Gender.male),
                    OfficePhone="1",
                    MobilePhone="1",
                    Position=Convert.ToInt32(Position.none),
                    JobTitle=Convert.ToInt32(JobTitle.engineer),
                    Education=Convert.ToInt32(Education.master),
                    HiredDate=DateTime.Parse("2012-01-20")
                },
                new Staff{
                    Id=Guid.NewGuid(),
                    No=1153,
                    Name="许智星",
                    Gender=Convert.ToInt32(Gender.female),
                    OfficePhone="1",
                    MobilePhone="1",
                    Position=Convert.ToInt32(Position.none),
                    JobTitle=Convert.ToInt32(JobTitle.engineer),
                    Education=Convert.ToInt32(Education.master),
                    HiredDate=DateTime.Parse("2015-01-20")
                },
                new Staff{
                    Id=Guid.NewGuid(),
                    No=1644,
                    Name="黄学漾",
                    Gender=Convert.ToInt32(Gender.male),
                    OfficePhone="1",
                    MobilePhone="1",
                    Position=Convert.ToInt32(Position.none),
                    JobTitle=Convert.ToInt32(JobTitle.advanceEngineer),
                    Education=Convert.ToInt32(Education.doctor),
                    HiredDate=DateTime.Parse("2015-01-20")
                },
                new Staff{
                    Id=Guid.NewGuid(),
                    No=1117,
                    Name="王曦强",
                    Gender=Convert.ToInt32(Gender.male),
                    OfficePhone="1",
                    MobilePhone="1",
                    Position=Convert.ToInt32(Position.none),
                    JobTitle=Convert.ToInt32(JobTitle.assistantEngineer),
                    Education=Convert.ToInt32(Education.undergraduate),
                    HiredDate=DateTime.Parse("2013-01-20")
                },
                new Staff{
                    Id=Guid.NewGuid(),
                    No=143,
                    Name="赖苍林",
                    Gender=Convert.ToInt32(Gender.male),
                    OfficePhone="1",
                    MobilePhone="2",
                    Position=Convert.ToInt32(Position.manager),
                    JobTitle=Convert.ToInt32(JobTitle.advanceEngineer),
                    Education=Convert.ToInt32(Education.master),
                    HiredDate=DateTime.Parse("2006-08-20")
                },
                new Staff{
                    Id=Guid.NewGuid(),
                    No=1169,
                    Name="黄玮",
                    Gender=Convert.ToInt32(Gender.female),
                    OfficePhone="1",
                    MobilePhone="3",
                    Position=Convert.ToInt32(Position.none),
                    JobTitle=Convert.ToInt32(JobTitle.advanceEngineer),
                    Education=Convert.ToInt32(Education.doctor),
                    HiredDate=DateTime.Parse("2012-08-20")
                },

            };
            foreach (Staff s in staffs)
            {
                context.Staffs.Add(s);
            }
            context.SaveChanges();

        
        }
    }
}
