using JourneyHero.Api.StoreB.Models;
using JourneyHero.Api.StoreB.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreB.Aplicacion.Consultas
{
    public class ConsultaRepuesto
    {
        public class GetRepuesto : IRequest<List<Repuesto>>
        {

        }

        public class Handler : IRequestHandler<GetRepuesto, List<Repuesto>>
        {
            private readonly ContextStoreB context;

            public Handler(ContextStoreB _context)
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
