using JourneyHero.Api.StoreC.Aplicacion;
using JourneyHero.Api.StoreC.Aplicacion.Consultas;
using JourneyHero.Api.StoreC.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly IMediator mediator;

        public CarroController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> AddMarca(NuevoCarro.Executer data)
        {
            return await mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<Carro>>> AllCarros()
        {
            var list = await mediator.Send(new ConsultaCarro.GetCarros());

            return list;
        }
    }
}
