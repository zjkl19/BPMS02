﻿using System;
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
    public class ProjectController : Controller
    {
        private IProjectRepository _mainRepository;
        private IBridgeRepository _bridgeRepository;
        private readonly IOptions<PageSettings> _pageSettings;

        public ProjectController(IProjectRepository mainRepository, IBridgeRepository bridgeRepository,IOptions<PageSettings> pageSettings)
        {
            _mainRepository = mainRepository;
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

            var re01 = await _mainRepository.Projects;
            var re02 = await _bridgeRepository.Bridges;
            var linqVar = from p in re01
                           join q in re02
                           on p.BridgeId equals q.Id
                           where p.ContractId==ContractId
                           select new ProjectBriefViewModel
                           {
                               Id = p.Id,
                               Name=p.Name,
                               BridgeName=q.Name
                           };

            var model = new ProjectBriefListViewModel
            {
                ProjectBriefViewModels = linqVar,
                ProjectBriefInfo = new ProjectBriefInfo
                {
                    TotalItems = linqVar.Count(),
                    //TotalStdValue
                    //TotalCalcValue

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