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
    public class ConsultaMarca
    {
        public class GetMarcas : IRequest<List<Marca>>
        {

        }

        public class Handler : IRequestHandler<GetMarcas, List<Marca>>
        {
            private readonly ContextStoreB context;

            public Handler(ContextStoreB _context)
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
