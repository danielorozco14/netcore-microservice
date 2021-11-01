using JourneyHero.Api.StoreC.Models;
using JourneyHero.Api.StoreC.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreC.Aplicacion.Consultas
{
    public class ConsultaRepuesto
    {
        public class GetRepuesto : IRequest<List<Repuesto>>
        {

        }

        public class Handler : IRequestHandler<GetRepuesto, List<Repuesto>>
        {
            private readonly ContextStoreC context;

            public Handler(ContextStoreC _context)
            {
                //Dependency Injection
                context = _context;
            }

            public async Task<List<Repuesto>> Handle(GetRepuesto request, CancellationToken cancellationToken)
            {
                var listRepuestos = await context.Repuestos.ToListAsync();

                return listRepuestos;
            }
        }
    }
}
