using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreC.Models
{
    public class Carro
    {
        public int CarroId { get; set; }
        public string nombreModelo { get; set; }
        public string anio { get; set; }
        //FOREIGN KEY
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }

        //Guid
        public string CarroGuid { get; set; }
    }
}
