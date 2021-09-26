using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unidad1Actividad2.Models
{
    public class PaginaPromediosViewModel
    {
        public int Promedio1 { get; set; }
        public int Promedio2 { get; set; }
        public int Promedio3 { get; set; }
        public int Prom { get { return (Promedio1 + Promedio2 + Promedio3) / 3; } }

        public string Aprobado
        {
            get {
                if (Prom >= 70)
                    return "Aprobado";
                else
                    return "No aprobado";
                        }
        }
}
    
    

    
}


