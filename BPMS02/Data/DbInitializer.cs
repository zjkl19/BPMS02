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
                    OfficePhone="0591-12345678",
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

            InitContract(context, staffs);

        }

        public static void InitContract(DataContext context,Staff[] staffs)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Contracts.Any())
            {
                return;   // DB has been seeded
            }

            var contracts = new Contract[]
            {
                new Contract{
                    Id=Guid.NewGuid(),
                    No="HT02CB1600200",
                    Name="莆田市x桥外观检查",
                    Amount=100000,
                    SignedDate=DateTime.Parse("2016-03-01"),
                    Deadline=30,
                    PromisedDeadline=28,
                    JobContent="1、上部结构外观检查;2、下部结构外观检查",
                    ProjectLocation="莆田",
                    Client="莆田市建设局",
                    ClientContactPerson="李工",
                    ClientContactPersonPhone="15804001234",
                    AcceptWay=(int)(AcceptWay.bid),
                    SignStatus=(int)(SignStatus.clientSigned),
                    AcceptStaff=staffs[0],
                    ResponseStaff=staffs[1]
                },
                new Contract{
                    Id=Guid.NewGuid(),
                    No="HT02CB1700201",
                    Name="福州市x桥荷载试验",
                    Amount=200000,
                    SignedDate=DateTime.Parse("2017-03-01"),
                    Deadline=40,
                    PromisedDeadline=35,
                    JobContent="1、桥梁动载试验;2、桥梁静载试验",
                    ProjectLocation="福州",
                    Client="福州市政工程管理处桥梁管理所",
                    ClientContactPerson="张三",
                    ClientContactPersonPhone="13904001111",
                    AcceptWay=(int)(AcceptWay.delegation),
                    SignStatus=(int)(SignStatus.clientSigned),
                    AcceptStaff=staffs[2],
                    ResponseStaff=staffs[3]
                },
                new Contract{
                    Id=Guid.NewGuid(),
                    No="HT02CB1800201",
                    Name="宁德市x桥常规定期检测",
                    Amount=300000,
                    SignedDate=DateTime.Parse("2018-03-25"),
                    Deadline=60,
                    PromisedDeadline=50,
                    JobContent="1、桥梁常规定期检测",
                    ProjectLocation="宁德",
                    Client="宁德市公路局",
                    ClientContactPerson="李工",
                    ClientContactPersonPhone="13812344321",
                    AcceptWay=(int)(AcceptWay.discussion),
                    SignStatus=(int)(SignStatus.corpSigned),
                    AcceptStaff=staffs[3],
                    ResponseStaff=staffs[4]
                }
            };
            foreach (Contract c in contracts)
            {
                context.Contracts.Add(c);
            }
            context.SaveChanges();

        }
    }
}

