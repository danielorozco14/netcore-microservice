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
                //AQUI VAS A METER LAS LISTAS NUEVAS DE LOS ENDPOINT Y ACA VAS A METER LAS LISTAS POR CADA TIENDA CORRESPONDIENTE.
                var listCarros = await context.Tiendas.ToListAsync();
                return listCarros;
            }
        }
    }
}
