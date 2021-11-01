using JourneyHero.Api.StoreC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreC.Persistence
{
    public class ContextStoreC: DbContext
    {
        public ContextStoreC(DbContextOptions<ContextStoreC> opts) : base(opts) { }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Repuesto> Repuestos { get; set; }


    }
}
