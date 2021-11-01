using FluentValidation;
using JourneyHero.Api.StoreA.Models;
using JourneyHero.Api.StoreA.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreA.Aplicacion
{
    public class NuevoRepuesto
    {
        public class Executer : IRequest
        {
            public string marcaCarro { get; set; }
            public string modeloCarro { get; set; }
            public string anio_carro { get; set; }
            public string nombreRepuesto { get; set; }
            public string marcaRepuesto { get; set; }
            public double precioRepuesto { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Executer>
        {
            public ExecuteValidation()
            {
                //Creating Validation Rules!
                RuleFor(x => x.marcaCarro).NotEmpty();
                RuleFor(x => x.modeloCarro).NotEmpty();
                RuleFor(x => x.anio_carro).NotEmpty();
                RuleFor(x => x.nombreRepuesto).NotEmpty();
                RuleFor(x => x.marcaRepuesto).NotEmpty();
                RuleFor(x => x.precioRepuesto).NotEmpty();

            }
        }



        public class Handler : IRequestHandler<Executer>
        {

            public readonly ContextRepuesto context;

            public Handler(ContextRepuesto contextRepuesto)
            {
                context = contextRepuesto;
            }

            public async Task<Unit> Handle(Executer request, CancellationToken cancellationToken)
            {
                //Adding new spare part into the DB. Request represents the incoming data.
                var repuesto = new Repuesto
                {
                    marca_carro = request.marcaCarro,
                    modelo_carro = request.modeloCarro,
                    anio_carro = request.anio_carro,
                    nombre_repuesto = request.nombreRepuesto,
                    marca_repuesto = request.marcaRepuesto,
                    precio_repuesto = request.precioRepuesto,
                    RepuestoGuid = Convert.ToString(Guid.NewGuid())
                };

                context.Repuestos.Add(repuesto);
                var valor = await context.SaveChangesAsync();

                return (valor > 0) ? Unit.Value : throw new Exception("There was an error while introducing a spare part into Store A");

            }
        }
    }
}