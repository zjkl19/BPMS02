using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPMS02.Areas.Dev.Models;
using BPMS02.Models;

namespace BPMS02.Data
{
    public class DbInitializer
    {
        private DataContext _context;

        public DbInitializer(DataContext context) => _context = context;

        //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
        public void Initialize()
        {

            _context.Database.EnsureCreated();

            // Look for any students.
            if (_context.Staffs.Any())
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
                _context.Staffs.Add(s);
            }
            _context.SaveChanges();

            Contract[] contracts =InitContract(staffs);
            Bridge[] bridges=InitBridge();
            Project[] projects = InitProject(contracts, bridges);
            StaffProject[] staffProjects = InitStaffProject(staffs,projects);

        }

        public Contract[] InitContract(Staff[] staffs)
        {
            _context.Database.EnsureCreated();

            // Look for any students.
            if (_context.Contracts.Any())
            {
                return null;   // DB has been seeded
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
                    AcceptStaffId=staffs[0].Id,
                    ResponseStaffId=staffs[1].Id
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
                    AcceptStaffId=staffs[2].Id,
                    ResponseStaffId=staffs[3].Id
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
                    AcceptStaffId=staffs[3].Id,
                    ResponseStaffId=staffs[4].Id
                }
            };
            foreach (Contract c in contracts)
            {
                _context.Contracts.Add(c);
            }
            _context.SaveChanges();

            return contracts;

        }
        public Bridge[] InitBridge()
        {
            _context.Database.EnsureCreated();

            // Look for any students.
            if (_context.Bridges.Any())
            {
                return null;   // DB has been seeded
            }
            var bridges = new Bridge[]
            {
                new Bridge{
                    Id=Guid.NewGuid(),
                    Name="莆田市过溪桥",
                    Length=125.0,
                    Width=8.5,
                    SpanNumber=1,
                    StructureType=(int)(StructureType.Suspension_CableStayed)
                },
                new Bridge{
                    Id=Guid.NewGuid(),
                    Name="莆田市城港大桥",
                    Length=100.0,
                    Width=10.0,
                    SpanNumber=1,
                    StructureType=(int)(StructureType.Arch)
                },
                new Bridge{
                    Id=Guid.NewGuid(),
                    Name="福州市x桥",
                    Length=30.0,
                    Width=14.0,
                    SpanNumber=1,
                    StructureType=(int)(StructureType.SimpleSupportedBeam)
                },
            };
            foreach (Bridge v in bridges)
            {
                _context.Bridges.Add(v);
            }
            _context.SaveChanges();

            return bridges;

        }
        public Project[] InitProject(Contract[] contracts,Bridge[] bridges)
        {
            _context.Database.EnsureCreated();

            // Look for any students.
            if (_context.Projects.Any())
            {
                return null;   // DB has been seeded
            }
            var projects = new Project[]
            {
                new Project{
                    Id=Guid.NewGuid(),
                    Name="莆田市过溪桥外观检测",
                    CreateTime=DateTime.Now,
                    BridgeId=bridges[0].Id,
                    ContractId=contracts[0].Id,
                    StandardValue=100000,
                    CalcValue =2000,
                    EnterProgress=(int)(EnterProgress.entered),
                    EnterDate=DateTime.Parse("2018-03-25"),
                    SiteProgress=(int)SiteProgress.Finished,
                    SiteFinishedDate=DateTime.Parse("2018-04-09"),
                    ExitDate=DateTime.Parse("2018-04-10"),
                    ReportProgress=(int)ReportProgress.notFinished,
                    ReportPublishedDate=null,
                    ReportNo="",
                    ProjectProgressExplanation="报告进度完成60%",
                    DelayDays=0,
                    DelayRate=0,
                },
                 new Project{
                    Id=Guid.NewGuid(),
                    Name="莆田市城港大桥检测",
                    CreateTime=DateTime.Now,
                    BridgeId=bridges[1].Id,
                    ContractId=contracts[0].Id,
                    StandardValue=200000,
                    CalcValue =4000,
                    EnterProgress=(int)(EnterProgress.entered),
                    EnterDate=DateTime.Parse("2018-02-28"),
                    SiteProgress=(int)SiteProgress.Finished,
                    SiteFinishedDate=DateTime.Parse("2018-03-05"),
                    ExitDate=DateTime.Parse("2018-03-06"),
                    ReportProgress=(int)ReportProgress.finished,
                    ReportPublishedDate=DateTime.Parse("2018-03-15"),
                    ReportNo="BG2018000001",
                    ProjectProgressExplanation="项目已完成",
                    DelayDays=0,
                    DelayRate=0,
                },
                new Project{
                    Id=Guid.NewGuid(),
                    Name="福州市x桥荷载试验",
                    CreateTime=DateTime.Now,
                    BridgeId=bridges[2].Id,
                    ContractId=contracts[1].Id,
                    StandardValue=150000,
                    CalcValue =3000,
                    EnterProgress=(int)(EnterProgress.notEntered),
                    EnterDate=null,
                    SiteProgress=(int)SiteProgress.notFinished,
                    SiteFinishedDate=null,
                    ExitDate=null,
                    ReportProgress=(int)ReportProgress.notFinished,
                    ReportPublishedDate=null,
                    ReportNo="",
                    ProjectProgressExplanation="项目正在进行进场前的准备",
                    DelayDays=0,
                    DelayRate=0,
                },

            };
            foreach (Project v in projects)
            {
                _context.Projects.Add(v);
            }
            _context.SaveChanges();
            return projects;
        }
        public StaffProject[] InitStaffProject(Staff[] staffs, Project[] projects)
        {
            _context.Database.EnsureCreated();

            // Look for any students.
            if (_context.StaffProjects.Any())
            {
                return null;   
            }
            var staffProjects = new StaffProject[]
            {
                new StaffProject{
                    Id=Guid.NewGuid(),
                    StaffId=staffs[0].Id,
                    ProjectId =projects[0].Id,
                    Labor =(int)Labor.response,
                    Ratio=Convert.ToDecimal(0.2),
                    StandardValue =0,
                    CalcValue=0,

                },
                new StaffProject{
                    Id=Guid.NewGuid(),
                    StaffId=staffs[0].Id,
                    ProjectId =projects[0].Id,
                    Labor =(int)Labor.siteWorking,
                    Ratio=0,
                    StandardValue =0,
                    CalcValue=0,

                },
                new StaffProject{
                    Id=Guid.NewGuid(),
                    StaffId=staffs[1].Id,
                    ProjectId =projects[0].Id,
                    Labor =(int)Labor.siteWorking,
                    Ratio=0,
                    StandardValue =0,
                    CalcValue=0,

                },
                 new StaffProject{
                    Id=Guid.NewGuid(),
                    StaffId=staffs[2].Id,
                    ProjectId =projects[0].Id,
                    Labor =(int)Labor.reportWriting,
                    Ratio=0,
                    StandardValue =0,
                    CalcValue=0,

                 },
                new StaffProject{
                    Id=Guid.NewGuid(),
                    StaffId=staffs[3].Id,
                    ProjectId =projects[1].Id,
                    Labor =(int)Labor.response,
                    Ratio=0,
                    StandardValue =0,
                    CalcValue=0,

                 },
            };
            foreach (StaffProject v in staffProjects)
            {
                _context.StaffProjects.Add(v);
            }
            _context.SaveChanges();
            return staffProjects;
        }
    }
}

