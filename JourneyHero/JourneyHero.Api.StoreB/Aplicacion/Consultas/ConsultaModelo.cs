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
    public class ConsultaModelo
    {
        public class GetModelos : IRequest<List<Modelo>>
        {

        }

        public class Handler : IRequestHandler<GetModelos, List<Modelo>>
        {
            private readonly ContextStoreB context;

            public Handler(ContextStoreB _context)
            {
                //Dependency Injection
                context = _context;
            }

            public async Task<List<Modelo>> Handle(GetModelos request, CancellationToken cancellationToken)
            {
                var listModelos = await context.Modelos.ToListAsync();

                return listModelos;
            }
        }
    }
}
