using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreB.Models
{
    public class Modelo
    {
        public int ModeloId { get; set; }
        public string nombreModelo { get; set; }

        //FOREIGN KEY
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }

        //GUID
        public string ModeloGuid { get; set; }

    }
}
