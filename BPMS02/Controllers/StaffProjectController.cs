using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BPMS02.Data;
using Microsoft.Extensions.Options;
using BPMS02.IRepository;
using BPMS02.ViewModels;

namespace BPMS02.Controllers
{
    public class StaffProjectController : Controller
    {
        private IStaffProjectRepository _mainRepository;
        private IStaffRepository _staffRepository;
        private IProjectRepository _projectRepository;
        private readonly IOptions<PageSettings> _pageSettings;

        public StaffProjectController(IStaffProjectRepository mainRepository, IStaffRepository staffRepository, IProjectRepository projectRepository, IOptions<PageSettings> pageSettings)
        {
            _mainRepository = mainRepository;
            _staffRepository = staffRepository;
            _projectRepository = projectRepository;
            _pageSettings = pageSettings;
        }

        // GET: StaffProject
        public ActionResult Index()
        {
            return View();
        }


        public async Task<PartialViewResult> ListByProjectId(Guid Id)
        {


            var re01 = await _mainRepository.StaffProjects;
            var re02 = await _staffRepository.Staffs;
            var linqVar = from p in re01
                          join q in re02
                          on p.StaffId equals q.Id
                          where p.ProjectId==Id
                          select new ProjectStaffProjectViewModel
                          {
                              Id = p.Id,
                              StaffName = q.Name,
                              Labor = (Labor)p.Labor,
                              Ratio = p.Ratio,
                              StandardValue = p.StandardValue,
                              CalcValue = p.CalcValue,
                          };

            var model = new ProjectStaffProjectListViewModel
            {
                ProjectStaffProjectViewModels = linqVar,

            };

            return PartialView("ProjectStaffProjectListPartial", model);
        }

        // GET: StaffProject/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StaffProject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffProject/Create
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

        // GET: StaffProject/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StaffProject/Edit/5
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

        // GET: StaffProject/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StaffProject/Delete/5
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