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
    public class NuevoModelo
    {
        public class Executer : IRequest
        {
            public string nombreModelo { get; set; }
            public int MarcaId { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Executer>
        {
            public ExecuteValidation()
            {
                //Creating Validation Rules!
                RuleFor(x => x.nombreModelo).NotEmpty();
                RuleFor(x => x.MarcaId).NotEmpty();
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
                var modelo = new Modelo
                {
                    nombreModelo = request.nombreModelo,
                    MarcaId = request.MarcaId,
                    ModeloGuid = Convert.ToString(Guid.NewGuid())
                };

                contextStoreB.Modelos.Add(modelo);
                var value = await contextStoreB.SaveChangesAsync();

                return (value > 0) ? Unit.Value : throw new Exception("There was an error adding a new Modelo!");

            }
        }
    }
}
