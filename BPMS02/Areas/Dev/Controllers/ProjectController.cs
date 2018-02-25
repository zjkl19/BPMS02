using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class ProjectController : Controller
    {
        private IProjectRepository _mainRepository;
        private readonly IOptions<PageSettings> _pageSettings;

        public ProjectController(IProjectRepository mainRepository, IOptions<PageSettings> pageSettings)
        {
            _mainRepository = mainRepository;
            _pageSettings = pageSettings;
        }
        // GET: Project
        public IActionResult Index()
        {
            return View();
        }
        public async Task<PartialViewResult> List()
        {
            int page = _pageSettings.Value.page;
            int pageSize = _pageSettings.Value.pageSize;

            var linqVar = await _mainRepository.ListAsync();

            var model = new ItemListViewModel<ProjectViewModel>
            {
                ItemViewModels = linqVar.Select(p => new ProjectViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreateTime = p.CreateTime,
                    StandardValue = p.StandardValue,
                    CalcValue = p.CalcValue,
                    EnterProgress = (EnterProgress)p.EnterProgress,
                    EnterDate = p.EnterDate,
                    SiteProgress = (SiteProgress)p.SiteProgress,
                    SiteFinishedDate = p.SiteFinishedDate,
                    ExitDate = p.ExitDate,
                    ReportProgress = (ReportProgress)p.ReportProgress,
                    ReportNo=p.ReportNo,
                    ReportPublishedDate=p.ReportPublishedDate,
                    DelayDays = p.DelayDays,
                    DelayRate = p.DelayRate,
                    ProjectProgressExplanation = p.ProjectProgressExplanation,
                    ContractId = p.ContractId,
                    BridgeId = p.BridgeId

                }).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = linqVar.Count()
                }

            };

            return PartialView("ProjectListPartial", model);
        }

        [HttpPost]
        public async Task<PartialViewResult> List(PagingInfo pagingInfo)
        {
            int page;
            int pageSize;

            if (ModelState.IsValid && TryValidateModel(pagingInfo))
            {
                page = pagingInfo.CurrentPage;
                pageSize = pagingInfo.ItemsPerPage;
            }
            else
            {
                page = 1;
                pageSize = 5;
            }

            var linqVar = await _mainRepository.ListAsync();

            var model = new ItemListViewModel<ProjectViewModel>
            {
                ItemViewModels = linqVar.Select(p => new ProjectViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreateTime = p.CreateTime,
                    StandardValue = p.StandardValue,
                    CalcValue = p.CalcValue,
                    EnterProgress = (EnterProgress)p.EnterProgress,
                    EnterDate = p.EnterDate,
                    SiteProgress = (SiteProgress)p.SiteProgress,
                    SiteFinishedDate = p.SiteFinishedDate,
                    ExitDate = p.ExitDate,
                    ReportProgress = (ReportProgress)p.ReportProgress,
                    ReportNo = p.ReportNo,
                    ReportPublishedDate = p.ReportPublishedDate,
                    DelayDays = p.DelayDays,
                    DelayRate = p.DelayRate,
                    ProjectProgressExplanation = p.ProjectProgressExplanation,
                    ContractId = p.ContractId,
                    BridgeId = p.BridgeId

                }).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = linqVar.Count()
                }

            };

            return PartialView("ProjectListPartial", model);
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Project/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _mainRepository.CreateAsync(new Project
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    CreateTime = model.CreateTime,
                    StandardValue = model.StandardValue,
                    CalcValue = model.CalcValue,
                    EnterProgress = (int)model.EnterProgress,
                    EnterDate = model.EnterDate,
                    SiteProgress = (int)model.SiteProgress,
                    SiteFinishedDate = model.SiteFinishedDate,
                    ExitDate = model.ExitDate,
                    ReportProgress = (int)model.ReportProgress,
                    DelayDays = model.DelayDays,
                    DelayRate = model.DelayRate,
                    ProjectProgressExplanation = model.ProjectProgressExplanation,
                    ContractId = model.ContractId,
                    BridgeId = model.BridgeId
                });

                TempData["message"] = "成功创建：" + model.Name + "";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Query(ProjectQuery projectQuery)
        {
            int page = _pageSettings.Value.page;
            int pageSize = _pageSettings.Value.pageSize;

            int ReportProgressUpperBound;   //上界
            int ReportProgressLowerBound;   //下界

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string nameQuery;
            nameQuery = projectQuery.Name ?? "";

            if ((int)projectQuery.ReportProgressQuery == int.MaxValue)    //判断是否为"任意"
            {
                ReportProgressUpperBound = int.MaxValue;
                ReportProgressLowerBound = 0;
            }
            else
            {
                ReportProgressUpperBound = (int)projectQuery.ReportProgressQuery;
                ReportProgressLowerBound = (int)projectQuery.ReportProgressQuery;
            }
            //var linq1 =await _mainRepository.Projects;

            var linqVar = _mainRepository.Projects.Result.Where(p => p.Name.Contains(nameQuery))
                .Where(p => (p.EnterDate > projectQuery.EnterDateAfter && p.EnterDate < projectQuery.EnterDateBefore))
                .Where(p => (p.SiteFinishedDate > projectQuery.SiteFinishedDateAfter && p.SiteFinishedDate < projectQuery.SiteFinishedDateBefore))
                .Where(p => (p.ReportProgress >= ReportProgressLowerBound && p.ReportProgress <= ReportProgressUpperBound));

            var model = new ItemListViewModel<ProjectViewModel>
            {
                ItemViewModels = linqVar.Select(p => new ProjectViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreateTime = p.CreateTime,
                    StandardValue = p.StandardValue,
                    CalcValue = p.CalcValue,
                    EnterProgress = (EnterProgress)p.EnterProgress,
                    EnterDate = p.EnterDate,
                    SiteProgress = (SiteProgress)p.SiteProgress,
                    SiteFinishedDate = p.SiteFinishedDate,
                    ExitDate = p.ExitDate,
                    ReportProgress = (ReportProgress)p.ReportProgress,
                    ReportNo = p.ReportNo,
                    ReportPublishedDate = p.ReportPublishedDate,
                    DelayDays = p.DelayDays,
                    DelayRate = p.DelayRate,
                    ProjectProgressExplanation = p.ProjectProgressExplanation,
                    ContractId = p.ContractId,
                    BridgeId = p.BridgeId

                }).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = linqVar.Count()
                }

            };

            return PartialView("ProjectListPartial", model);
        }


        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Project/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}