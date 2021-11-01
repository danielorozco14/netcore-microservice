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
    public class NuevoMarca
    {
       
        public class Executer : IRequest
        {
            public string nombreMarca { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Executer>
        {
            public ExecuteValidation()
            {
                //Creating Validation Rules!
                RuleFor(x => x.nombreMarca).NotEmpty();
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
                var marca = new Marca
                {
                    nombreMarca = request.nombreMarca,
                    MarcaGuid = Convert.ToString(Guid.NewGuid())
                };

                contextStoreC.Marcas.Add(marca);
                var value = await contextStoreC.SaveChangesAsync();

                return (value > 0) ? Unit.Value : throw new Exception("There was an error adding a new Marca!");

            }
        }
    }
}
