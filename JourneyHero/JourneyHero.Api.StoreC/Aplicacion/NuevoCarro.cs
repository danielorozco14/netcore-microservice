using FluentValidation;
using JourneyHero.Api.StoreC.Models;
using JourneyHero.Api.StoreC.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreC.Aplicacion
{
    public class NuevoCarro
    {
        public class Executer : IRequest
        {
            public string nombreModelo { get; set; }
            public string anio { get; set; }
            public int MarcaId { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Executer>
        {
            public ExecuteValidation()
            {
                //Creating Validation Rules!
                RuleFor(x => x.nombreModelo).NotEmpty();
                RuleFor(x => x.anio).NotEmpty();
                RuleFor(x => x.MarcaId).NotEmpty();

            }
        }


        public class Handler : IRequestHandler<Executer>
        {
            public readonly ContextStoreC contextStoreC;

            public Handler(ContextStoreC context)
            {
                //Dependency Injection
                contextStoreC = context;
            }

            public async Task<Unit> Handle(Executer request, CancellationToken cancellationToken)
            {
                var carro = new Carro
                {
                    nombreModelo = request.nombreModelo,
                    anio = request.anio,
                    MarcaId = request.MarcaId,
                    CarroGuid = Convert.ToString(Guid.NewGuid())
                };

                contextStoreC.Carros.Add(carro);
                var value = await contextStoreC.SaveChangesAsync();

                return (value > 0) ? Unit.Value : throw new Exception("There was an error adding a new Carro!");

            }
        }
    }
}
