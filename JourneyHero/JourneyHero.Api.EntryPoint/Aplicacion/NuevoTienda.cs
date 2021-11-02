using FluentValidation;
using JourneyHero.Api.EntryPoint.Models;
using JourneyHero.Api.EntryPoint.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JourneyHero.Api.EntryPoint.Aplicacion
{
    public class NuevoTienda
    {
        public class Executer : IRequest
        {
            public string nombreTienda { get; set; }
            public string direccion { get; set; }
            public double latitud { get; set; }
            public double longitud { get; set; }
            public string telefono { get; set; }
            public double rating { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Executer>
        {
            public ExecuteValidation()
            {
                //Creating Validation Rules!
                RuleFor(x => x.nombreTienda).NotEmpty();
                RuleFor(x => x.direccion).NotEmpty();
                RuleFor(x => x.latitud).NotEmpty();
                RuleFor(x => x.longitud).NotEmpty();
                RuleFor(x => x.telefono).NotEmpty();
                RuleFor(x => x.rating).NotEmpty();
            }
        }


        public class Handler : IRequestHandler<Executer>
        {
            public readonly ContextEP contextEP;

            public Handler(ContextEP context)
            {
                //Dependency Injection
                contextEP = context;
            }

            public async Task<Unit> Handle(Executer request, CancellationToken cancellationToken)
            {
                var tienda = new Tienda
                {
                    nombreTienda = request.nombreTienda,
                    direccion = request.direccion,
                    latitud = request.latitud,
                    longitud = request.longitud,
                    telefono = request.telefono,
                    rating = request.rating,
                    StoreGuid= Convert.ToString(Guid.NewGuid())

                };

                contextEP.Tiendas.Add(tienda);
                var value = await contextEP.SaveChangesAsync();

                return (value > 0) ? Unit.Value : throw new Exception("There was an error adding a new Tienda!");

            }
        }
    }
}
