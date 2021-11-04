using JourneyHero.Api.EntryPoint.Aplicacion.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.EntryPoint.RemoteInterface
{
    public interface IProductosService
    {
        Task<(bool resultado, List<ProductosDto> prod, string Error)> GetProductos();
    }
}
