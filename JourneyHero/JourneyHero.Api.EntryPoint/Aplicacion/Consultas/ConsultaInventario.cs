using JourneyHero.Api.EntryPoint.Persistence;
using JourneyHero.Api.EntryPoint.RemoteInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JourneyHero.Api.EntryPoint.Aplicacion.Consultas
{
    public class ConsultaInventario
    {
        public class Executer : IRequest<List<ProductosDto>>
        {
            public string nombreMarca { get; set; }
            public string nombreModelo { get; set; }
            public string anio { get; set; }
            public string nombreRepuesto { get; set; }
            public double precio { get; set; }
            public string marcaRepuesto { get; set; }
        }

        public class Handler : IRequestHandler<Executer, List<ProductosDto>>
        {
            private readonly ContextEP context;
            private readonly IProductosService productosService;

            public Handler(ContextEP _context, IProductosService _productosService)
            {
                context = _context;
                productosService = _productosService;
            }

            public async Task<List<ProductosDto>> Handle(Executer request, CancellationToken cancellationToken)
            {
                
                var listProductos = new List<ProductosDto>();
                var response = await productosService.GetProductos();

                if (response.resultado)
                {
                    foreach (var obj in response.prod)
                    {
                        var newPro = new ProductosDto
                        {
                            marcaRepuesto = obj.marcaRepuesto,
                            nombreModelo = obj.nombreModelo,
                            precio = obj.precio,
                            nombreMarca = obj.nombreMarca,
                            anio = obj.anio,
                            nombreRepuesto = obj.nombreRepuesto
                        };
                        listProductos.Add(newPro);
                    }                   
                    
                }
                return listProductos;
            }
        }
    }
}
