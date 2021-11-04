using JourneyHero.Api.EntryPoint.Aplicacion.Consultas;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.EntryPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IMediator mediator;

        public InventarioController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductosDto>>> ProductosB()
        {
            
            var list = await mediator.Send(new ConsultaInventario.Executer());
            

            return list;
        }
    }
}
