using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace BPMS02.Controllers
{   
    public class DevController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}