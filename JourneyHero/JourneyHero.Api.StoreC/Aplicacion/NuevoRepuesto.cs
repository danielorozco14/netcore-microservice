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
    public class NuevoRepuesto
    {
        public class Executer : IRequest
        {
            public string nombreRepuesto { get; set; }
            public string marcaRepuesto { get; set; }
            public int CarroId { get; set; }
            public float precio { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Executer>
        {
            public ExecuteValidation()
            {
                //Creating Validation Rules!
                RuleFor(x => x.nombreRepuesto).NotEmpty();
                RuleFor(x => x.marcaRepuesto).NotEmpty();
                RuleFor(x => x.CarroId).NotEmpty();
                RuleFor(x => x.precio).NotEmpty();


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
                var repuesto = new Repuesto
                {
                    nombreRepuesto = request.nombreRepuesto,
                    marcaRepuesto = request.marcaRepuesto,
                    precio = request.precio,
                    CarroId = request.CarroId,
                    RepuestoGuid = Convert.ToString(Guid.NewGuid())
                };

                contextStoreC.Repuestos.Add(repuesto);
                var value = await contextStoreC.SaveChangesAsync();

                return (value > 0) ? Unit.Value : throw new Exception("There was an error adding a new Repuesto!");

            }
        }
    }
}
