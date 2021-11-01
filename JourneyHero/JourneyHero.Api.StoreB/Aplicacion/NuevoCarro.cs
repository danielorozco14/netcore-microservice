using FluentValidation;
using JourneyHero.Api.StoreB.Models;
using JourneyHero.Api.StoreB.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreB.Aplicacion
{
    public class NuevoCarro
    {
        public class Executer : IRequest
        {
            public string anio { get; set; }
            public int ModeloId { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Executer>
        {
            public ExecuteValidation()
            {
                //Creating Validation Rules!
                RuleFor(x => x.anio).NotEmpty();
                RuleFor(x => x.ModeloId).NotEmpty();
            }
        }


        public class Handler : IRequestHandler<Executer>
        {
            public readonly ContextStoreB contextStoreB;

            public Handler(ContextStoreB context)
            {
                //Dependency Injection
                contextStoreB = context;
            }

            public async Task<Unit> Handle(Executer request, CancellationToken cancellationToken)
            {
                var carro = new Carro
                {
                    anio = request.anio,
                    ModeloId = request.ModeloId,
                    CarroGuid = Convert.ToString(Guid.NewGuid())
                };

                contextStoreB.Carros.Add(carro);
                var value = await contextStoreB.SaveChangesAsync();

                return (value > 0) ? Unit.Value : throw new Exception("There was an error adding a new Carro!");

            }
        }
    }
}
