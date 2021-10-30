using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooPlanet.Models.ViewModels
{
    public class HabitatViewModel
    {
        public IEnumerable<Especies> Habitats { get; set; } 

        public IEnumerable<Especies> Especies { get; set; }

    }
}
