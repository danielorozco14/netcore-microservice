using JourneyHero.Api.EntryPoint.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.EntryPoint.Persistence
{
    public class ContextEP:DbContext
    {
        public ContextEP(DbContextOptions<ContextEP> opts) : base(opts) { }

        public DbSet<Tienda> Tiendas { get; set; }
       /* public DbSet<TiendaA> TiendasA { get; set; }
        public DbSet<TiendaB> TiendasB { get; set; }
        public DbSet<TiendaC> TiendasC { get; set; }*/


    }
}
