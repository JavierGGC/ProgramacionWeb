using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooPlanet.Models;
using ZooPlanet.Models.ViewModels;

namespace ZooPlanet.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Especie")]
        public IActionResult Especie()
        {
            animalesContext context = new animalesContext();
            var especies = context.Clases.Include(x => x.Especies).OrderBy(x => x.Nombre)
            .Select(x => new EspeciesViewModel { NombreEspecie = x.Nombre, Especies = x.Especies });

            return View(especies);
        }

        [Route("/Habitat")]
        public IActionResult Habitat()
        {
            animalesContext context = new animalesContext();
            var habitat = context.Especies.Select(x => new Especies { Habitat = x.Habitat }).Distinct();
            HabitatViewModel vwm = new HabitatViewModel();
            vwm.Habitats = habitat;
            vwm.Especies = context.Especies.Include(x => x.IdClaseNavigation);
            return View(vwm);

            
        }
    }


}
