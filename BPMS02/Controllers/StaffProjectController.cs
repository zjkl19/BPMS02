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
using BPMS02.Models;

namespace BPMS02.Controllers
{
    public class StaffProjectController : Controller
    {
        private IStaffProjectRepository _mainRepository;
        private IStaffRepository _staffRepository;
        private IProjectRepository _projectRepository;
        private IProjectInspectionTypeRepository _projectInspectionTypeRepository;
        private readonly IOptions<PageSettings> _pageSettings;

        public StaffProjectController(IStaffProjectRepository mainRepository, IStaffRepository staffRepository, IProjectRepository projectRepository, IProjectInspectionTypeRepository projectInspectionTypeRepository,IOptions<PageSettings> pageSettings)
        {
            _mainRepository = mainRepository;
            _staffRepository = staffRepository;
            _projectRepository = projectRepository;
            _projectInspectionTypeRepository=projectInspectionTypeRepository;
            _pageSettings = pageSettings;
        }

        // GET: StaffProject
        public ActionResult Index()
        {
            return View();
        }


        public async Task<PartialViewResult> ListByProjectId(Guid Id)
        {


            var re01 = _mainRepository.EntityItems;
            var re02 = _staffRepository.EntityItems;
            var linqVar = await(from p in re01
                          join q in re02
                          on p.StaffId equals q.Id
                          where p.ProjectId==Id
                          select new ProjectStaffProjectViewModel
                          {
                              Id = p.Id,
                              StaffName = q.Name,
                              Labor = (Labor)p.Labor,
                              Ratio = p.Ratio,
                              StandardValue = (p.Ratio)*_projectInspectionTypeRepository.GetStdValueByProjectId(p.ProjectId),
                              CalcValue = (p.Ratio) * _projectInspectionTypeRepository.GetCalcValueByProjectId(p.ProjectId),

                          }).ToAsyncEnumerable().ToList();

            var re = await _projectRepository.QueryByIdAsync(Id);

            var model = new ProjectStaffProjectListViewModel
            {
                ProjectId = Id,
                ProjectName = re.Name,
                ProjectStaffProjectViewModels = linqVar,

            };

            return PartialView("ProjectStaffProjectListPartial", model);
        }

        // GET: StaffProject/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<IActionResult> CreateByProjectId(Guid Id)
        {
            var linqVar = await _projectRepository.QueryByIdAsync(Id);
            var model = new CreateStaffProjectViewModel{
                ProjectId=Id,
                ProjectName= linqVar.Name,
                ProjectStdValue=_projectInspectionTypeRepository.GetStdValueByProjectId(Id),
                ProjectCalcValue= _projectInspectionTypeRepository.GetCalcValueByProjectId(Id)
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateByProjectId(CreateStaffProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _mainRepository.CreateAsync(new StaffProject
                {
                    Id = Guid.NewGuid(),
                    Labor=(int)model.Labor,
                    Ratio=model.Ratio,
                    ProjectId=model.ProjectId,
                    StaffId=model.StaffId,
                });

                TempData["globalMessage"] = "成功创建职工参与信息" ;
                
            }
            catch(Exception ex)
            {
                throw (ex);
            }
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