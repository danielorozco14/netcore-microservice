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
    public class ConsultaRepuesto
    {
        public class GetRepuestos : IRequest<List<Repuesto>>
        {

        }

        public class Handler : IRequestHandler<GetRepuestos, List<Repuesto>>
        {
            private readonly ContextRepuesto context;

            public Handler(ContextRepuesto _context)
            {
                //Dependency Injection
                context = _context;
            }

            public async Task<List<Repuesto>> Handle(GetRepuestos request, CancellationToken cancellationToken)
            {
                var listRepuestos = await context.Repuestos.ToListAsync();
                return listRepuestos;
            }
        }
    }
}
