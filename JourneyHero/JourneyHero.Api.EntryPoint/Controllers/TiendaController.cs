using JourneyHero.Api.EntryPoint.Aplicacion;
using JourneyHero.Api.EntryPoint.Aplicacion.Consultas;
using JourneyHero.Api.EntryPoint.Models;
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
    public class TiendaController : ControllerBase
    {
        private readonly IMediator mediator;

        public TiendaController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> AddMarca(NuevoTienda.Executer data)
        {
            return await mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<Tienda>>> AllCarros()
        {
            var list = await mediator.Send(new ConsultaTienda.GetTiendas());

            return list;
        }
    }
}
