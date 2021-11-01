using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreC.Models
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string nombreMarca { get; set; }
        //Guid
        public string MarcaGuid { get; set; }
    }
}
