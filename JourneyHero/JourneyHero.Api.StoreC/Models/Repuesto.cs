using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreC.Models
{
    public class Repuesto
    {
        public int RepuestoId { get; set; }
        public string nombreRepuesto { get; set; }
        public double precio { get; set; }
        public string marcaRepuesto { get; set; }

        //FOREIGN KEY
        public int CarroId { get; set; }
        public Carro Carro { get; set; }
        //Guid
        public string RepuestoGuid { get; set; }

    }
}
