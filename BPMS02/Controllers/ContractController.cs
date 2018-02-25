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
    public class ContractController : Controller
    {
        private IContractRepository _mainRepository;
        private IStaffRepository _staffRepository;
        private readonly IOptions<PageSettings> _pageSettings;

        public ContractController(IContractRepository mainRepository, IStaffRepository staffRepository, IOptions<PageSettings> pageSettings)
        {
            _mainRepository = mainRepository;
            _staffRepository = staffRepository;
            _pageSettings = pageSettings;
        }
        // GET: Contract
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 列表选择合同
        /// </summary>
        /// <returns></returns>
        public async Task<PartialViewResult> SelectList()
        {
            int page = _pageSettings.Value.page;
            int pageSize = _pageSettings.Value.pageSize;

            var re01 = await _mainRepository.Contracts;
            var re02 = await _staffRepository.Staffs;
            var linqVar = (from p in re01
                           join q in re02
                           on p.ResponseStaffId equals q.Id
                           select new ContractSelectViewModel
                           {
                               Id = p.Id,
                               No = p.No,
                               Name = p.Name,
                               ResponseStaffName = q.Name
                           }).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize);

            var model = new ItemListViewModel<ContractSelectViewModel>
            {
                ItemViewModels = linqVar,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = linqVar.Count()
                }

            };

            return PartialView("ContractSelectListPartial", model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<PartialViewResult> SelectList(PagingInfo pagingInfo)
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

            var re01 = await _mainRepository.Contracts;
            var re02 = await _staffRepository.Staffs;
            var linqVar = (from p in re01
                           join q in re02
                           on p.ResponseStaffId equals q.Id
                           select new ContractSelectViewModel
                           {
                               Id = p.Id,
                               No = p.No,
                               Name = p.Name,
                               ResponseStaffName = q.Name
                           }).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize);

            var model = new ItemListViewModel<ContractSelectViewModel>
            {
                ItemViewModels = linqVar,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = linqVar.Count()
                }

            };

            return PartialView("ContractSelectListPartial", model);
        }

        // GET: Contract/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contract/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contract/Create
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

        // GET: Contract/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contract/Edit/5
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

        // GET: Contract/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contract/Delete/5
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