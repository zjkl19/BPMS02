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
    public class ProjectController : Controller
    {
        private IProjectRepository _mainRepository;
        private IProjectInspectionTypeRepository _projectInspectionTypeRepository;
        private IContractRepository _contractRepository;
        private IBridgeRepository _bridgeRepository;
        private readonly IOptions<PageSettings> _pageSettings;

        public ProjectController(IProjectRepository mainRepository, IProjectInspectionTypeRepository projectInspectionTypeRepository, IContractRepository contractRepository,IBridgeRepository bridgeRepository, IOptions<PageSettings> pageSettings)
        {
            _mainRepository = mainRepository;
            _projectInspectionTypeRepository = projectInspectionTypeRepository;
            _contractRepository = contractRepository;
            _bridgeRepository = bridgeRepository;
            _pageSettings = pageSettings;
        }
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<PartialViewResult> BriefList(Guid ContractId)
        {

            var re01 = _mainRepository.EntityItems;
            var re02 = _bridgeRepository.EntityItems;

            //var linqVar = await re01.Join(
            //    re02,
            //    p => p.ContractId,
            //    q => (Guid?)(q.Id),
            //    (p, q) => new ProjectBriefViewModel
            //    {
            //        Id = p.Id,
            //        Name = p.Name,
            //        BridgeName = q.Name
            //    }).ToAsyncEnumerable().ToList();

            var linqVar = await (from p in re01
                           join q in re02
                           on p.BridgeId equals q.Id
                           where p.ContractId == ContractId
                           select new ProjectBriefViewModel
                           {
                               Id = p.Id,
                               Name = p.Name,                               
                               BridgeName = q.Name,
                               InspectionType= _projectInspectionTypeRepository.GetInspTypeNameByProjectId(p.Id),
                               StandardValue = _projectInspectionTypeRepository.GetStdValueByProjectId(p.Id),
                               CalcValue= _projectInspectionTypeRepository.GetCalcValueByProjectId(p.Id)
                           }).ToAsyncEnumerable().ToList();

            var TotalStdValue = (from p in linqVar
                       select p).Sum(t => t.StandardValue);

            var model = new ProjectBriefListViewModel
            {
                ContractId = ContractId,
                ProjectBriefViewModels = linqVar,
                ProjectBriefInfo = new ProjectBriefInfo
                {
                    TotalItems = linqVar.Count(),
          
                    TotalStdValue = TotalStdValue,
                    TotalCalcValue = (from p in linqVar
                                      select p).Sum(t => t.CalcValue),

                }

            };

            return PartialView("ProjectBriefListPartial", model);
        }



        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> CreateByContractId(Guid Id)
        {
            var linqVar = await _contractRepository.QueryByIdAsync(Id);
            return View(new CreateProjectViewModel
            {
                ContractId = Id,
                ContractName=linqVar.Name,
            });
        }

        // POST: Project/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateByContractId(CreateProjectViewModel model)
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
                    CreateTime = DateTime.Now.Date,
                    EnterProgress = (int)model.EnterProgress,
                    EnterDate = model.EnterDate,
                    SiteProgress = (int)model.SiteProgress,
                    SiteFinishedDate = model.SiteFinishedDate,
                    ExitDate = model.ExitDate,
                    ReportProgress = (int)model.ReportProgress,
                    ProjectProgressExplanation = model.ProjectProgressExplanation,
                    ContractId = model.ContractId,
                    BridgeId = model.BridgeId
                });

                TempData["globalMessage"] = "成功创建：" + model.Name + "";

                
            }
            catch(Exception ex)
            {
                throw (ex); 
            }
            return View();
        }

        // POST: Project/Create
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