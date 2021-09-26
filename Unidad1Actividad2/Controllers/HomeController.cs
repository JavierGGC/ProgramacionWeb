using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unidad1Actividad2.Models;

namespace Unidad1Actividad2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(PaginaPromediosViewModel vm)
        {
            return View(vm);
        }


    }
}
