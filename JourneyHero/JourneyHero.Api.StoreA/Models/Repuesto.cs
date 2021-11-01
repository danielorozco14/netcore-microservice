using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreA.Models
{
    public class Repuesto
    {
       public int id { get; set; }
        public string marca_carro { get; set; }
        public string modelo_carro { get; set; }
        public string anio_carro { get; set; }
        public string nombre_repuesto { get; set; }
        public string marca_repuesto { get; set; }
        public double precio_repuesto { get; set; }

        //
        public string RepuestoGuid { get; set; }

    }
}
