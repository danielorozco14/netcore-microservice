using JourneyHero.Api.StoreA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreA.Persistence
{
    public class ContextRepuesto : DbContext
    {
        public ContextRepuesto(DbContextOptions<ContextRepuesto> options) : base(options)
        {

        }

        public DbSet<Repuesto> Repuestos { get; set; }
    }
}
