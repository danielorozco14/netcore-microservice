using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreB.Models
{
    public class Marca
    {
        public int MarcaId {get;set;}
        public string nombreMarca { get; set; }
        
        //GUID
        public string MarcaGuid { get; set; }
    }
}
