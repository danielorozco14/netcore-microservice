﻿using JourneyHero.Api.StoreB.Aplicacion;
using JourneyHero.Api.StoreB.Aplicacion.Consultas;
using JourneyHero.Api.StoreB.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.StoreB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly IMediator mediator;

        public ModeloController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> AddMarca(NuevoModelo.Executer data)
        {
            return await mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<Modelo>>> AllModelos()
        {
            var list = await mediator.Send(new ConsultaModelo.GetModelos());

            return list;
        }
    }
}
