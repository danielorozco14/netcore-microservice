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
    public class ConsultaMarca
    {
        public class GetMarcas : IRequest<List<Marca>>
        {

        }

        public class Handler : IRequestHandler<GetMarcas, List<Marca>>
        {
            private readonly ContextStoreC context;

            public Handler(ContextStoreC _context)
            {
                //Dependency Injection
                context = _context;
            }

            public async Task<List<Marca>> Handle(GetMarcas request, CancellationToken cancellationToken)
            {
                var listMarcas = await context.Marcas.ToListAsync();

                return listMarcas;
            }
        }
    }
}
