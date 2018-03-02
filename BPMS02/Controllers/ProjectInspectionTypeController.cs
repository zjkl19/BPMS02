using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPMS02.Data;
using BPMS02.IRepository;
using BPMS02.Models;
using BPMS02.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BPMS02.Controllers
{
    public class ProjectInspectionTypeController : Controller
    {
        private IProjectInspectionTypeRepository _mainRepository;
        private IProjectRepository _projectRepository;
        private readonly IOptions<PageSettings> _pageSettings;

        public ProjectInspectionTypeController(IProjectInspectionTypeRepository mainRepository, IProjectRepository projectRepository, IOptions<PageSettings> pageSettings)
        {
            _mainRepository = mainRepository;
            _projectRepository = projectRepository;
            _pageSettings = pageSettings;
        }

        // GET: ProjectInspectionType
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProjectInspectionType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public async Task<IActionResult> CreateByProjectId(Guid Id)
        {
            var linqVar = await _projectRepository.QueryByIdAsync(Id);
            return View(
                new CreateProjectInspectionTypeViewModel
                {
                    ProjectId = Id,
                    ProjectName = linqVar.Name,
                });
        }
        // GET: ProjectInspectionType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectInspectionType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateByProjectId(CreateProjectInspectionTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _mainRepository.CreateAsync(new ProjectInspectionType
                {
                    Id = Guid.NewGuid(),
                    ProjectId = model.ProjectId,
                    InspectionTypeId = model.InspectionTypeId,
                    StandardValue = model.StandardValue,
                    CalcValue = model.CalcValue,

                });

                TempData["globalMessage"] = "成功为项目:"+model.ProjectName+"添加：" + model.InspectionTypeName + "检测类型";


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return View();
        }

        // GET: ProjectInspectionType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectInspectionType/Edit/5
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

        // GET: ProjectInspectionType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectInspectionType/Delete/5
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