using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.EntryPoint.Aplicacion.Consultas
{
    public class ProductosDto
    {
        public int ProductosDtoId { get; set; }
        public string nombreMarca { get; set; }
        public string nombreModelo { get; set; }
        public string anio { get; set; }
        public string nombreRepuesto { get; set; }
        public double precio { get; set; }
        public string marcaRepuesto { get; set; }
  
    }
}
