using System;
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
    public class BridgeController : Controller
    {
        private IBridgeRepository _mainRepository;
        private readonly IOptions<PageSettings> _pageSettings;

        public BridgeController(IBridgeRepository mainRepository, IOptions<PageSettings> pageSettings)
        {
            _mainRepository = mainRepository;
            _pageSettings = pageSettings;
        }
        // GET: Bridge
        public ActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> List()
        {
            int pageIndex = _pageSettings.Value.page;
            int pageSize = _pageSettings.Value.pageSize;

            Expression<Func<Bridge, Guid>> orderBy = x => x.Id;
            var pageResult = await _mainRepository.PageListAsync<Guid>(orderBy, pageIndex, pageSize);


            var model = new ItemListViewModel<BridgeSelectViewModel>
            {
                ItemViewModels = pageResult.Item1.Select(p => new BridgeSelectViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Width = p.Width,
                    Length = p.Length,
                    SpanNumber = p.SpanNumber,
                    StructureType = (StructureType)p.StructureType,
                    Comment = p.Comment
                }),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageIndex,
                    ItemsPerPage = pageSize,
                    TotalItems = pageResult.Item2,
                }

            };

            return PartialView("BridgeSelectListPartial", model);
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

            Expression<Func<Bridge, Guid>> orderBy = x => x.Id;
            var pageResult = await _mainRepository.PageListAsync<Guid>(orderBy, pageIndex, pageSize);


            var model = new ItemListViewModel<BridgeSelectViewModel>
            {
                ItemViewModels = pageResult.Item1.Select(p => new BridgeSelectViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Width = p.Width,
                    Length = p.Length,
                    SpanNumber = p.SpanNumber,
                    StructureType = (StructureType)p.StructureType,
                    Comment = p.Comment
                }),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageIndex,
                    ItemsPerPage = pageSize,
                    TotalItems = pageResult.Item2,
                }

            };

            return PartialView("BridgeSelectListPartial", model);
        }


        public async Task<PartialViewResult> QueryByName(string Name)
        {
            int pageIndex = 1;
            int pageSize = 5;

            var varQuery = await _mainRepository.QueryByNameAsync(Name);

            var model = new ItemListViewModel<BridgeSelectViewModel>
            {
                ItemViewModels = varQuery.Select(p => new BridgeSelectViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Width = p.Width,
                    Length = p.Length,
                    SpanNumber = p.SpanNumber,
                    StructureType = (StructureType)p.StructureType,
                    Comment = p.Comment
                }).OrderBy(p => p.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageIndex,
                    ItemsPerPage = pageSize,
                    TotalItems = varQuery.Count()
                }

            };

            return PartialView("BridgeSelectListPartial", model);
        }

        // GET: Bridge/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bridge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bridge/Create
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

        // GET: Bridge/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bridge/Edit/5
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

        // GET: Bridge/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bridge/Delete/5
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