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
    public class ConsultaCarro
    {
        public class GetCarros : IRequest<List<Carro>>
        {

        }

        public class Handler : IRequestHandler<GetCarros, List<Carro>>
        {
            private readonly ContextStoreB context;

            public Handler(ContextStoreB _context)
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
