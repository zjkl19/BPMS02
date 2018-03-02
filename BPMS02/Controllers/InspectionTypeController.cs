﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public class InspectionTypeController : Controller
    {
        private IInspectionTypeRepository _mainRepository;
        private readonly IOptions<PageSettings> _pageSettings;
        public InspectionTypeController(IInspectionTypeRepository mainRepository, IOptions<PageSettings> pageSettings)
        {
            _mainRepository = mainRepository;
            _pageSettings = pageSettings;
        }
        // GET: InspectionType
        public ActionResult Index()
        {
            return View();
        }

        // GET: InspectionType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public async Task<PartialViewResult> List()
        {
            int pageIndex = _pageSettings.Value.page;
            int pageSize = _pageSettings.Value.pageSize;

            Expression<Func<InspectionType, Guid>> orderBy = x => x.Id;
            var pageResult = await _mainRepository.PageListAsync<Guid>(orderBy, pageIndex, pageSize);

            var model = new ItemListViewModel<InspectionTypeSelectViewModel>
            {
                ItemViewModels = pageResult.Item1.Select(p => new InspectionTypeSelectViewModel
                {
                    Id = p.Id,
                    Type = p.Type,
                    Name = p.Name
                }),


                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageIndex,
                    ItemsPerPage = pageSize,
                    TotalItems = pageResult.Item2,
                }

            };

            return PartialView("InspectionTypeSelectListPartial", model);
        }

        [HttpPost]
        public async Task<PartialViewResult> List(PagingInfo pagingInfo)
        {
            int pageIndex;
            int pageSize;

            if (ModelState.IsValid && TryValidateModel(pagingInfo))
            {
                pageIndex = pagingInfo.CurrentPage;
                pageSize = pagingInfo.ItemsPerPage;
            }
            else
            {
                pageIndex = 1;
                pageSize = 5;
            }


            Expression<Func<InspectionType, Guid>> orderBy = x => x.Id;
            var pageResult = await _mainRepository.PageListAsync<Guid>(orderBy, pageIndex, pageSize);

            var model = new ItemListViewModel<InspectionTypeSelectViewModel>
            {
                ItemViewModels = pageResult.Item1.Select(p => new InspectionTypeSelectViewModel
                {
                    Id = p.Id,
                    Type = p.Type,
                    Name = p.Name
                }),


                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageIndex,
                    ItemsPerPage = pageSize,
                    TotalItems = pageResult.Item2,
                }

            };

            return PartialView("InspectionTypeSelectListPartial", model);
        }

        // GET: InspectionType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InspectionType/Create
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

        // GET: InspectionType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InspectionType/Edit/5
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

        // GET: InspectionType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InspectionType/Delete/5
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