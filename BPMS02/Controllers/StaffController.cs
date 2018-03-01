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
using System.Linq.Expressions;
using BPMS02.Models;

namespace BPMS02.Controllers
{
    public class StaffController : Controller
    {
        private IStaffRepository _mainRepository;
        private readonly IOptions<PageSettings> _pageSettings;
        public StaffController(IStaffRepository mainRepository, IOptions<PageSettings> pageSettings)
        {
            _mainRepository = mainRepository;
            _pageSettings = pageSettings;
        }

        [NonAction]
        public IActionResult Index()
        {
            return View();
        }


        public async Task<PartialViewResult> List()
        {
            int pageIndex = _pageSettings.Value.page;
            int pageSize = _pageSettings.Value.pageSize;

            Expression<Func<Staff, Guid>> orderBy = x => x.Id;
            var pageResult = await _mainRepository.PageListAsync<Guid>(orderBy, pageIndex, pageSize);

            var model = new ItemListViewModel<StaffSelectViewModel>
            {
                ItemViewModels = pageResult.Item1.Select(p => new StaffSelectViewModel
                {
                    Id = p.Id,
                    No = p.No,
                    Name = p.Name,
                    Position = (Position)(p.Position),
                    JobTitle = (JobTitle)(p.JobTitle)

                }),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageIndex,
                    ItemsPerPage = pageSize,
                    TotalItems = pageResult.Item2
                }

            };

            return PartialView("~/Views/Shared/StaffSelectListPartial.cshtml", model);
        }

        [HttpPost]
        public async Task<PartialViewResult> List(StaffSelectListViewModel vm)
        {
            int pageIndex;
            int pageSize;

            if (ModelState.IsValid && TryValidateModel(vm.PagingInfo))
            {
                pageIndex = vm.PagingInfo.CurrentPage;
                pageSize = vm.PagingInfo.ItemsPerPage;
            }
            else
            {
                pageIndex = 1;
                pageSize = 5;
            }

            Expression<Func<Staff, Guid>> orderBy = x => x.Id;
            var pageResult = await _mainRepository.PageListAsync<Guid>(orderBy, pageIndex, pageSize);

            var model = new ItemListViewModel<StaffSelectViewModel>
            {
                ItemViewModels = pageResult.Item1.Select(p => new StaffSelectViewModel
                {
                    Id = p.Id,
                    No = p.No,
                    Name = p.Name,
                    Position = (Position)(p.Position),
                    JobTitle = (JobTitle)(p.JobTitle)
                }).OrderBy(p => p.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageIndex,
                    ItemsPerPage = pageSize,
                    TotalItems = pageResult.Item2
                }

            };

            return PartialView("~/Views/Shared/StaffSelectListPartial.cshtml", model);
        }

        public async Task<PartialViewResult> QueryByNo(int No)
        {
            int page = 1;
            int pageSize = 5;

            var stf = await _mainRepository.QueryByNoAsync(No);

            var model = new ItemListViewModel<StaffSelectViewModel>
            {
                ItemViewModels = stf.Select(p => new StaffSelectViewModel
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

            var stf = await _mainRepository.QueryByNameAsync(Name);

            var model = new ItemListViewModel<StaffSelectViewModel>
            {
                ItemViewModels = stf.Select(p => new StaffSelectViewModel
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