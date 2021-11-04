using FluentValidation;
using JourneyHero.Api.EntryPoint.Aplicacion.Consultas;
using JourneyHero.Api.EntryPoint.Models;
using JourneyHero.Api.EntryPoint.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
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
            public List<ProductosDto> productos { get; set; }
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
                RuleFor(x => x.productos).NotEmpty();
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

           /* public List<ProductosDto> productosB(string URL)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:23745");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = client.GetAsync(URL).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var dataObjects = response.Content.ReadAsStringAsync();
                    var opts = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<List<ProductosDto>>(dataObjects.Result, opts);
                    foreach (var d in dataObjects)
                    {
                        Console.WriteLine("{0}", d.Name);
                    }
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }

                //Make any other calls using HttpClient here.

                //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
                client.Dispose();
                return null;
            }
*/
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
