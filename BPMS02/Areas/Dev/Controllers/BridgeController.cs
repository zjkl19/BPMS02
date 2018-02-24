﻿using System;
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
    public class BridgeController : Controller
    {
        private IBridgeRepository _bridgeRepository;
        private readonly IOptions<PageSettings> _pageSettings;

        public BridgeController(IBridgeRepository bridgeRepository, IOptions<PageSettings> pageSettings)
        {
            _bridgeRepository = bridgeRepository;
            _pageSettings = pageSettings;
        }

        // GET: Bridge
        public IActionResult Index() => View();

        public async Task<PartialViewResult> List()
        {
            int page = _pageSettings.Value.page;
            int pageSize = _pageSettings.Value.pageSize;

            var bdg = await _bridgeRepository.ListAsync();

            var model = new BridgeListViewModel
            {
                BridgeViewModels = bdg.Select(p => new BridgeViewModel
                {
                    Id=p.Id,
                    Name = p.Name,
                    Width = p.Width,
                    Length = p.Length,
                    SpanNumber = p.SpanNumber,
                    StructureType = (StructureType)p.StructureType,
                    Comment = p.Comment
                }).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = bdg.Count()
                }

            };

            return PartialView("BridgeListPartial", model);
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

            var bdg = await _bridgeRepository.ListAsync();

            var model = new BridgeListViewModel
            {
                BridgeViewModels = bdg.Select(p => new BridgeViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Width = p.Width,
                    Length = p.Length,
                    SpanNumber = p.SpanNumber,
                    StructureType = (StructureType)p.StructureType,
                    Comment = p.Comment
                }).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = bdg.Count()
                }

            };

            return PartialView("BridgeListPartial", model);
        }


        public async Task<PartialViewResult> QueryByName(string Name)
        {
            int page = 1;
            int pageSize = 5;

            var varQuery = await _bridgeRepository.QueryByNameAsync(Name);

            var model = new BridgeListViewModel
            {
                BridgeViewModels = varQuery.Select(p => new BridgeViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Width = p.Width,
                    Length = p.Length,
                    SpanNumber = p.SpanNumber,
                    StructureType = (StructureType)p.StructureType,
                    Comment = p.Comment
                }).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = varQuery.Count()
                }

            };

            return PartialView("BridgeListPartial", model);
        }


        // GET: Bridge/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bridge/Create
        public IActionResult Create() => View();

        // POST: Bridge/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBridgeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _bridgeRepository.CreateAsync(new Bridge
                {
                    Id = Guid.NewGuid(),
                    Name=model.Name,
                    Width=model.Width,
                    Length=model.Length,
                    SpanNumber=model.SpanNumber,
                    StructureType=(int)model.StructureType,
                    Comment=model.Comment
                });

                TempData["message"] = "成功创建：" + model.Name+"";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Bridge/Edit/5
        public async Task<IActionResult> Edit(Guid Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var varToEdit = await _bridgeRepository.QueryByIdAsync(Id);

            var model = new EditBridgeViewModel
            {
                Id = Id,
                Name = varToEdit.Name,
                Width = varToEdit.Width,
                Length = varToEdit.Length,
                SpanNumber = varToEdit.SpanNumber,
                StructureType = (StructureType)varToEdit.StructureType,
                Comment = varToEdit.Comment
            };

            return View(model);

        }

        // POST: Bridge/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid Id, EditBridgeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _bridgeRepository.EditAsync(new Bridge
                {
                    Id = Id,
                    Name = model.Name,
                    Width = model.Width,
                    Length = model.Length,
                    SpanNumber = model.SpanNumber,
                    StructureType = (int)model.StructureType,
                    Comment = model.Comment
                });

                TempData["message"] = "Edit Successful!";

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                ModelState.AddModelError("", "无法保存更改。 " +
                 "请重试, 如果该问题仍然存在 " +
                 "请联系系统管理员。");
                return View();
            }
        }

        // GET: Bridge/Delete/5
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var varDeleted = await _bridgeRepository.Delete(Id);
                if (varDeleted != null)
                {
                    TempData["message"] = string.Format("{0}数据已被删除", varDeleted.Name);
                }

            }
            catch
            {
                TempData["message"] = "删除失败。请重试, 如果该问题仍然存在 " + "请联系系统管理员。";
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Bridge/Delete/5
        [NonAction]
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