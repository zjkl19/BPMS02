using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPMS02.Data;
using BPMS02.IRepository;
using BPMS02.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BPMS02.Controllers
{
    public class ProjectInspectionTypeController : Controller
    {
        private IProjectInspectionTypeRepository _mainRepository;
        private readonly IOptions<PageSettings> _pageSettings;

        public ProjectInspectionTypeController(IProjectInspectionTypeRepository mainRepository, IOptions<PageSettings> pageSettings)
        {
            _mainRepository = mainRepository;
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
        public IActionResult CreateByProjectId(Guid Id)
        {
            return View(
                new ProjectInspectionTypeViewModel
                {
                    ProjectId = Id,
                    ProjectName="",
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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