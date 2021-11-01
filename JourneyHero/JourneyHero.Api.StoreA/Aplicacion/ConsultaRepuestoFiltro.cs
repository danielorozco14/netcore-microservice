using JourneyHero.Api.StoreA.Models;
using JourneyHero.Api.StoreA.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreA.Aplicacion
{
    public class ConsultaRepuestoFiltro
    {
        public class RepuestoPorCriterio : IRequest<Repuesto>
        {
            public string RepuestoGuid { get; set; }
        }

        public class Handler : IRequestHandler<RepuestoPorCriterio, Repuesto>
        {
            private readonly ContextRepuesto context;

            public Handler(ContextRepuesto _context)
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
