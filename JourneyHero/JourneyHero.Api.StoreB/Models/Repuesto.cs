using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreB.Models
{
    public class Repuesto
    {
        public int RepuestoId { get; set; }
        public string nombreRepuesto { get; set; }
        public double precio { get; set; }

        //FOREIGN KEYS
        public int MarcaId { get; set; }
        public int CarroId { get; set; }

        public Marca Marca { get; set; }
        public Carro Carro { get; set; }

        //GUID
        public string RepuestoGuid { get; set; }

    }
}
