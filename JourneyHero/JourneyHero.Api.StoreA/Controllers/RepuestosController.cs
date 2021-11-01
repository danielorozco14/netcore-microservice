using JourneyHero.Api.StoreA.Aplicacion;
using JourneyHero.Api.StoreA.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepuestosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RepuestosController(IMediator mediator)
        {
            //Dependency Injection
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Insertar(NuevoRepuesto.Executer newData)
        {
            return await _mediator.Send(newData);
        }

        [HttpGet]
        public async Task<ActionResult<List<Repuesto>>> AllRepuestos()
        {
            var list = await _mediator.Send(new ConsultaRepuesto.GetRepuestos());
          /*  foreach(Repuesto e in list)
            {
                System.Diagnostics.Debug.WriteLine(e.marca_carro);

            }*/
            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Repuesto>> GetRepuestoUnico(string id)
        {
            return await _mediator.Send(new ConsultaRepuestoFiltro.RepuestoPorCriterio { RepuestoGuid = id });
        }

    }
}
