using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BPMS02.Areas.Dev.Models;
using BPMS02.Models;


using BPMS02.Data;
using Microsoft.Extensions.Options;
using BPMS02.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BPMS02.Areas.Dev.Controllers
{
    [Area("Dev")]
    public class StaffController : Controller
    {

        private IStaffRepository _mainRepository;
        private readonly IOptions<PageSettings> _pageSettings;
        public StaffController(IStaffRepository mainRepository, IOptions<PageSettings> pageSettings)
        {
            _mainRepository = mainRepository;
            _pageSettings = pageSettings;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> CheckNo([Bind(include:"No")]CreateStaffViewModel model)
        {
            string message = null;
            var stf = await _mainRepository.QueryByNoAsync(model.No);
            if (stf.Count>0)
            {
                message = "工号" + model.No +"已被注册";
                return Json(message);
            }
            else
            {
                return Json(true);
            }
            
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateStaffViewModel model)
        {
            var stf = await _mainRepository.QueryByNoAsync(model.No);
            if (stf.Count > 0)
            {
                ModelState.AddModelError("No", "服务端验证：该工号" + model.No + "已被注册");
                
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _mainRepository.CreateAsync(new Staff
                {
                    Id = Guid.NewGuid(),
                    No = model.No,
                    Name = model.Name,
                    Gender = (int)model.Gender,
                    OfficePhone = model.OfficePhone,
                    MobilePhone = model.MobilePhone,
                    Position = (int)(model.Position),
                    JobTitle = (int)(model.JobTitle),
                    Education = (int)(model.Education),
                    HiredDate = model.HiredDate
                });

                TempData["globalMessage"] = "成功创建工号"+model.No+"职工";
            }
            catch (DbUpdateException /* ex */)
            {

                // Log the error(uncomment ex variable name and write a log.
                ModelState.AddModelError("", "无法新建。 " +
                 "请重试, 如果该问题仍然存在 " +
                 "请联系系统管理员。");
            }

            
            return View();
        }

        public async Task<PartialViewResult> List()
        {
            int pageIndex = _pageSettings.Value.page;
            int pageSize = _pageSettings.Value.pageSize;

            Expression<Func<Staff, Guid>> orderBy = x => x.Id;
            var pageResult = await _mainRepository.PageListAsync<Guid>(orderBy, pageIndex, pageSize);

            var model = new ItemListViewModel<StaffViewModel>
            {
                ItemViewModels = pageResult.Item1.Select(p => new StaffViewModel
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
                }),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageIndex,
                    ItemsPerPage = pageSize,
                    TotalItems = pageResult.Item2
                }

            };

            return PartialView("StaffListPartial", model);
        }

        //参考《精通ASP.NET MVC5》P156
        [HttpPost]
        public async Task<PartialViewResult> List(StaffListViewModel vm)
        {
            int pageIndex;
            int pageSize;
            
            if (ModelState.IsValid  && TryValidateModel(vm.PagingInfo))
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

            var model = new ItemListViewModel<StaffViewModel>
            {
                ItemViewModels = pageResult.Item1.Select(p => new StaffViewModel
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
                }),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageIndex,
                    ItemsPerPage = pageSize,
                    TotalItems = pageResult.Item2
                }

            };

            return PartialView("StaffListPartial", model);
        }

        public async Task<PartialViewResult> QueryByNo(int No)
        {
            int page=1;
            int pageSize=5;

            var stf =await _mainRepository.QueryByNoAsync(No);

            var model = new ItemListViewModel<StaffViewModel>
            {
                ItemViewModels = stf.Select(p => new StaffViewModel
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

            return PartialView("StaffListPartial", model);
        }

        public async Task<PartialViewResult> QueryByName(string Name)
        {
            int page = 1;
            int pageSize = 5;

            var stf = await _mainRepository.QueryByNameAsync(Name);

            var model = new ItemListViewModel<StaffViewModel>
            {
                ItemViewModels = stf.Select(p => new StaffViewModel
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

            return PartialView("StaffListPartial", model);
        }

        public async Task<IActionResult> Edit(Guid Id)
        {
            if(Id==null)
            {
                return NotFound();
            }
            var staffToEdit = await _mainRepository.QueryByIdAsync(Id);

            var model = new EditStaffViewModel
            {
                Id = staffToEdit.Id,
                No = staffToEdit.No,
                Name = staffToEdit.Name,
                Gender = (Gender)(staffToEdit.Gender),
                OfficePhone = staffToEdit.OfficePhone,
                MobilePhone = staffToEdit.MobilePhone,
                Position = (Position)(staffToEdit.Position),
                JobTitle = (JobTitle)(staffToEdit.JobTitle),
                Education = (Education)(staffToEdit.Education),
                HiredDate = staffToEdit.HiredDate
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditStaffViewModel model)
        {
            //ModelState.Remove("No");    工号不可更改

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _mainRepository.EditAsync(new Staff
                {
                    Id = model.Id,
                    No = model.No,
                    Name = model.Name,
                    Gender = (int)model.Gender,
                    OfficePhone = model.OfficePhone,
                    MobilePhone = model.MobilePhone,
                    Position = (int)(model.Position),
                    JobTitle = (int)(model.JobTitle),
                    Education = (int)(model.Education),
                    HiredDate = model.HiredDate
                });

                TempData["globalMessage"] = "成功编辑";
            }
            catch (DbUpdateException /* ex */)
            {
                // Log the error(uncomment ex variable name and write a log.
                ModelState.AddModelError("", "无法保存更改。 " +
                 "请重试, 如果该问题仍然存在 " +
                 "请联系系统管理员。");
            }

            return View(model);
        }
        
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var deletedStaff = await _mainRepository.Delete(Id);
                if (deletedStaff != null)
                {
                    TempData["globalMessage"] = string.Format("工号{0}数据已被删除", deletedStaff.No);
                }
            }
            catch (DbUpdateException /* ex */)
            {
                TempData["globalMessage"] = "删除失败。请重试, 如果该问题仍然存在 " + "请联系系统管理员。";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}