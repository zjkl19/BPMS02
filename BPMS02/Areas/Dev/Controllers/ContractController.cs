using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BPMS02.Data;
using Microsoft.Extensions.Options;
using BPMS02.IRepository;
using Microsoft.EntityFrameworkCore;
using BPMS02.Areas.Dev.Models;
using BPMS02.Models;

namespace BPMS02.Areas.Dev.Controllers
{
    [Area("Dev")]
    public class ContractController : Controller
    {
        private IContractRepository _contractRepository;
        private readonly IOptions<PageSettings> _pageSettings;
        public ContractController(IContractRepository contractRepository, IOptions<PageSettings> pageSettings)
        {
            _contractRepository = contractRepository;
            _pageSettings = pageSettings;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> VerifyContractNo([Bind(include: "No")]CreateContractViewModel model)
        {
            string message = null;
            var cnt = await _contractRepository.QueryByNoAsync(model.No);
            if (cnt.Count > 0)
            {
                message = "已存在合同编号：" + model.No;
                return Json(message);
            }
            else
            {
                return Json(true);
            }

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContractViewModel model)
        {
            var cnt = await _contractRepository.QueryByNoAsync(model.No);
            if (cnt.Count > 0)
            {
                ModelState.AddModelError("No", "已存在合同编号：" + model.No);

            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _contractRepository.CreateAsync(new Contract
                {
                    Id = Guid.NewGuid(),
                    No = model.No,
                    Name = model.Name,
                    Amount = model.Amount,
                    SignedDate = model.SignedDate,
                    Deadline = model.Deadline,
                    PromisedDeadline = model.PromisedDeadline,
                    JobContent = model.JobContent,
                    ProjectLocation = model.ProjectLocation,
                    Client = model.Client,
                    ClientContactPerson = model.ClientContactPerson,
                    ClientContactPersonPhone = model.ClientContactPersonPhone,
                    AcceptWay = (int)(model.AcceptWay),
                    SignStatus = (int)(model.SignStatus),
                    AcceptStaffId=model.AcceptStaffId,
                    ResponseStaffId=model.ResponseStaffId
                    
                });

                TempData["message"] = "创建成功";
            }
            catch (DbUpdateException /* ex */)
            {

                // Log the error(uncomment ex variable name and write a log.
                ModelState.AddModelError("", "无法保存更改。 " +
                 "请重试, 如果该问题仍然存在 " +
                 "请联系系统管理员。");
            }


            return View();
        }

        public async Task<PartialViewResult> List()
        {
            int page = _pageSettings.Value.page;
            int pageSize = _pageSettings.Value.pageSize;

            var cnt = await _contractRepository.ListAsync();

            var model = new ContractListViewModel
            {
                ContractViewModels = cnt.Select(p => new ContractViewModel
                {
                    Id = p.Id,
                    No = p.No,
                    Name = p.Name,
                    Amount = p.Amount,
                    SignedDate = p.SignedDate,
                    Deadline = p.Deadline,
                    PromisedDeadline = p.PromisedDeadline,
                    JobContent = p.JobContent,
                    ProjectLocation =p.ProjectLocation,
                    Client = p.Client,
                    ClientContactPerson=p.ClientContactPerson,
                    ClientContactPersonPhone = p.ClientContactPersonPhone,
                    AcceptWay =(AcceptWay)(p.AcceptWay),
                    SignStatus=(SignStatus)(p.SignStatus),
                }).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize),


                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = cnt.Count()
                }

            };

            return PartialView("~/Views/Shared/ContractListPartial.cshtml", model);
        }

        [HttpPost]
        public async Task<PartialViewResult> List(StaffListViewModel vm)
        {
            int page;
            int pageSize;

            if (ModelState.IsValid && TryValidateModel(vm.PagingInfo))
            {
                page = vm.PagingInfo.CurrentPage;
                pageSize = vm.PagingInfo.ItemsPerPage;
            }
            else
            {
                page = 1;
                pageSize = 5;
            }

            var cnt = await _contractRepository.ListAsync();

            var model = new ContractListViewModel
            {
                ContractViewModels = cnt.Select(p => new ContractViewModel
                {
                    Id = p.Id,
                    No = p.No,
                    Name = p.Name,
                    Amount = p.Amount,
                    SignedDate = p.SignedDate,
                    Deadline = p.Deadline,
                    PromisedDeadline = p.PromisedDeadline,
                    JobContent = p.JobContent,
                    ProjectLocation = p.ProjectLocation,
                    Client = p.Client,
                    ClientContactPerson = p.ClientContactPerson,
                    AcceptWay = (AcceptWay)(p.AcceptWay),
                    SignStatus = (SignStatus)(p.SignStatus),
                }).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = cnt.Count()
                }

            };

            return PartialView("~/Views/Shared/ContractListPartial.cshtml", model);
        }

        public async Task<PartialViewResult> QueryByNo(string No)
        {
            int page = 1;
            int pageSize = 5;

            var cnt = await _contractRepository.QueryByNoAsync(No);

            var model = new ContractListViewModel
            {
                ContractViewModels = cnt.Select(p => new ContractViewModel
                {
                    Id = p.Id,
                    No = p.No,
                    Name = p.Name,
                    Amount = p.Amount,
                    SignedDate = p.SignedDate,
                    Deadline = p.Deadline,
                    PromisedDeadline = p.PromisedDeadline,
                    JobContent = p.JobContent,
                    ProjectLocation = p.ProjectLocation,
                    Client = p.Client,
                    ClientContactPerson = p.ClientContactPerson,
                    AcceptWay = (AcceptWay)(p.AcceptWay),
                    SignStatus = (SignStatus)(p.SignStatus),
                }).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = cnt.Count()
                }

            };

            return PartialView("/Views/Shared/StaffListPartial.cshtml", model);
        }

        public async Task<PartialViewResult> QueryByName(string Name)
        {
            int page = 1;
            int pageSize = 5;

            var stf = await _staffRepository.QueryByNameAsync(Name);

            var model = new StaffListViewModel
            {
                StaffViewModels = stf.Select(p => new StaffViewModel
                {
                    Id = p.Id,
                    No = p.No,
                    Name = p.Name,
                    Gender = (Gender)(p.Gender),
                    OfficePhone = p.OfficePhone,
                    MobilePhone = p.MobilePhone,
                    Position = (Position)(p.Position),
                    JobTitle = (JobTitle)(p.JobTitle),
                    Education = (Education)(p.Education),
                    HiredDate = p.HiredDate
                }).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = stf.Count()
                }

            };

            return PartialView("~/Views/Shared/StaffListPartial.cshtml", model);
        }
    }
}