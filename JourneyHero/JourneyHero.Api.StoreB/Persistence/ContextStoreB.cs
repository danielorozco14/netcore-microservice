using JourneyHero.Api.StoreB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreB.Persistence
{
    public class ContextStoreB:DbContext
    {
        public ContextStoreB(DbContextOptions<ContextStoreB> opts) : base(opts) { }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Repuesto> Repuestos { get; set; }


    }
}
