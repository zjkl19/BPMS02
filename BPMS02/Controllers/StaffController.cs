using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


using BPMS02.Data;
using Microsoft.Extensions.Options;
using BPMS02.IRepository;
using Microsoft.EntityFrameworkCore;
using BPMS02.ViewModels;

namespace BPMS02.Controllers
{
    public class StaffController : Controller
    {
        private IStaffRepository _staffRepository;
        private readonly IOptions<PageSettings> _pageSettings;
        public StaffController(IStaffRepository staffRepository, IOptions<PageSettings> pageSettings)
        {
            _staffRepository = staffRepository;
            _pageSettings = pageSettings;
        }

        [NonAction]
        public IActionResult Index()
        {
            return View();
        }


        public async Task<PartialViewResult> List()
        {
            int page = _pageSettings.Value.page;
            int pageSize = _pageSettings.Value.pageSize;

            var stf = await _staffRepository.ListAsync();

            var model = new StaffSelectListViewModel
            {
                StaffSelectViewModels = stf.Select(p => new StaffSelectViewModel
                {
                    Id = p.Id,
                    No = p.No,
                    Name = p.Name,
                    Position = (Position)(p.Position),
                    JobTitle = (JobTitle)(p.JobTitle)

                }).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = stf.Count()
                }

            };

            return PartialView("~/Views/Shared/StaffSelectListPartial.cshtml", model);
        }

        [HttpPost]
        public async Task<PartialViewResult> List(StaffSelectListViewModel vm)
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

            var stf = await _staffRepository.ListAsync();

            var model = new StaffSelectListViewModel
            {
                StaffSelectViewModels = stf.Select(p => new StaffSelectViewModel
                {
                    Id = p.Id,
                    No = p.No,
                    Name = p.Name,
                    Position = (Position)(p.Position),
                    JobTitle = (JobTitle)(p.JobTitle)
                }).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = stf.Count()
                }

            };

            return PartialView("~/Views/Shared/StaffSelectListPartial.cshtml", model);
        }

        public async Task<PartialViewResult> QueryByNo(int No)
        {
            int page = 1;
            int pageSize = 5;

            var stf = await _staffRepository.QueryByNoAsync(No);

            var model = new StaffSelectListViewModel
            {
                StaffSelectViewModels = stf.Select(p => new StaffSelectViewModel
                {
                    Id = p.Id,
                    No = p.No,
                    Name = p.Name,
                    Position = (Position)(p.Position),
                    JobTitle = (JobTitle)(p.JobTitle)
                }).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = stf.Count()
                }

            };

            return PartialView("~/Views/Shared/StaffSelectListPartial.cshtml", model);
        }

        public async Task<PartialViewResult> QueryByName(string Name)
        {
            int page = 1;
            int pageSize = 5;

            var stf = await _staffRepository.QueryByNameAsync(Name);

            var model = new StaffSelectListViewModel
            {
                StaffSelectViewModels = stf.Select(p => new StaffSelectViewModel
                {
                    Id = p.Id,
                    No = p.No,
                    Name = p.Name,
                    Position = (Position)(p.Position),
                    JobTitle = (JobTitle)(p.JobTitle),
                }).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = stf.Count()
                }

            };

            return PartialView("~/Views/Shared/StaffSelectListPartial.cshtml", model);
        }

    }
}