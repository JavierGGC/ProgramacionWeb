using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unidad1Actividad1.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hola";
        }
        public IActionResult MiPerfil()
        {
            return View();
        }
    }
}
