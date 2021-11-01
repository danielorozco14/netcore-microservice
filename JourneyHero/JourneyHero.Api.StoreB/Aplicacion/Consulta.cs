using JourneyHero.Api.StoreB.Models;
using JourneyHero.Api.StoreB.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreB.Aplicacion
{
    public class Consulta
    {
        public class RepuestoPorCriterio : IRequest<Repuesto>
        {
            public string RepuestoGuid { get; set; }
        }

        public class Handler : IRequestHandler<RepuestoPorCriterio, Repuesto>
        {
            private readonly ContextStoreB context;

            public Handler(ContextStoreB _context)
            {
                context = _context;
            }

            public async Task<Repuesto> Handle(RepuestoPorCriterio request, CancellationToken cancellationToken)
            {
                var repuesto = await context.Repuestos.Where(x => x.RepuestoGuid == request.RepuestoGuid).FirstOrDefaultAsync();

                return (repuesto == null) ? throw new Exception("Repuesto not found") : repuesto;
            }
        }
    }
}
