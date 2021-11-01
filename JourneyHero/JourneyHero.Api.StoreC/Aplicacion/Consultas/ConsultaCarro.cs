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
    public class ConsultaCarro
    {
        public class GetCarros : IRequest<List<Carro>>
        {

        }

        public class Handler : IRequestHandler<GetCarros, List<Carro>>
        {
            private readonly ContextStoreC context;

            public Handler(ContextStoreC _context)
            {
                //Dependency Injection
                context = _context;
            }

            public async Task<List<Carro>> Handle(GetCarros request, CancellationToken cancellationToken)
            {
                var listCarros = await context.Carros.ToListAsync();

                return listCarros;
            }
        }
    }
}
