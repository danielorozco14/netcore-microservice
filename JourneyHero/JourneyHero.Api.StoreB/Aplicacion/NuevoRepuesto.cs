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
    public class NuevoRepuesto
    {
        public class Executer : IRequest
        {
            public string nombreRepuesto { get; set; }
            public double precio { get; set; }

            public int MarcaId { get; set; }
            public int CarroId { get; set; }

        }

        public class ExecuteValidation : AbstractValidator<Executer>
        {
            public ExecuteValidation()
            {
                //Creating Validation Rules!
                RuleFor(x => x.nombreRepuesto).NotEmpty();
                RuleFor(x => x.precio).NotEmpty();

                RuleFor(x => x.MarcaId).NotEmpty();
                RuleFor(x => x.CarroId).NotEmpty();

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
                var repuesto = new Repuesto
                {
                    nombreRepuesto = request.nombreRepuesto,
                    precio = request.precio,
                    CarroId = request.CarroId,
                    MarcaId = request.MarcaId,
                    RepuestoGuid = Convert.ToString(Guid.NewGuid())
                };

                contextStoreB.Repuestos.Add(repuesto);
                var value = await contextStoreB.SaveChangesAsync();

                return (value > 0) ? Unit.Value : throw new Exception("There was an error adding a new Repuesto!");

            }
        }
    }
}
