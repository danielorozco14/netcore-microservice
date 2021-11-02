using JourneyHero.Api.EntryPoint.Models;
using JourneyHero.Api.EntryPoint.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JourneyHero.Api.EntryPoint.Aplicacion.Consultas
{
    public class ConsultaTienda
    {
        public class GetTiendas : IRequest<List<Tienda>>
        {

        }

        public class Handler : IRequestHandler<GetTiendas, List<Tienda>>
        {
            private readonly ContextEP context;

            public Handler(ContextEP _context)
            {
                //Dependency Injection
                context = _context;
            }

            public async Task<List<Tienda>> Handle(GetTiendas request, CancellationToken cancellationToken)
            {
                var listTiendas = await context.Tiendas.ToListAsync();

                return listTiendas;
            }
        }
    }
}
