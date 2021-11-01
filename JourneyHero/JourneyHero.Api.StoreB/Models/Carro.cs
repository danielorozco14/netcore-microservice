using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreB.Models
{
    public class Carro
    {
        public int CarroId { get; set; }
        public string anio { get; set; }

        //FOREIGN KEYS
        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }

        //GUID
        public string CarroGuid { get; set; }
    }
}
