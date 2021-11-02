using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.EntryPoint.Models
{
    public class Tienda
    {
        public int TiendaId { get; set; }
        public string nombreTienda { get; set; }
        public string direccion { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public string telefono { get; set; }
        public double rating { get; set; }

        //Guid
        public string StoreGuid { get; set; }
    }
}
