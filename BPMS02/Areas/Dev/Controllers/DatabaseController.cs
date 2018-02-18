using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPMS02.Data;
using BPMS02.Models;
using Microsoft.AspNetCore.Mvc;


namespace BPMS02.Areas.Dev.Controllers
{
    [Area("Dev")]
    public class DatabaseController : Controller
    {
        private readonly DataContext _context;

        public DatabaseController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Initialize()
        {
            DbInitializer.Initialize(_context);
            TempData["message"] = "Initialize Successful!";
            return RedirectToAction("Index","Dev", new { area = "" });
        }
    }
}