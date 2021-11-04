using JourneyHero.Api.EntryPoint.Aplicacion.Consultas;
using JourneyHero.Api.EntryPoint.RemoteInterface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JourneyHero.Api.EntryPoint.RemoteService
{
    public class ProductoService : IProductosService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<ProductoService> _logger;

        public ProductoService(IHttpClientFactory httpClient, ILogger<ProductoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;

        }
        public async Task<(bool resultado, List<ProductosDto> prod, string Error)> GetProductos()
        {
            try
            {
                //BASE URL CONFIG ON STARTUP.cs
                var cliente = _httpClient.CreateClient("TiendaB");
                var response = await cliente.GetAsync("api/inventario");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var opts = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result =  JsonSerializer.Deserialize<List<ProductosDto>>(content, opts);

                    return (true, result, null);
                }
                return (false, null, response.ReasonPhrase);
            }catch(Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
