using JourneyHero.Api.StoreC.Aplicacion.Consultas;
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
    public class InventarioController : ControllerBase
    {
        private readonly IMediator mediator;

        public InventarioController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        /*[HttpGet]
        public async Task<ActionResult<List<Inventario>>> AllMarcas()
        {
            var listCarros = await mediator.Send(new ConsultaCarro.GetCarros());
            var listMarcas = await mediator.Send(new ConsultaMarca.GetMarcas());
            var listRepuestos = await mediator.Send(new ConsultaRepuesto.GetRepuesto());

            var list = from carro in listCarros
                       join repuesto in listRepuestos on carro.CarroId equals repuesto.CarroId
                       join modelo in listModelos on carro.ModeloId equals modelo.ModeloId
                       join marcas in listMarcas on modelo.MarcaId equals marcas.MarcaId
                       select new Inventario
                       {
                           nombreMarca = marcas.nombreMarca,
                           nombreModelo = modelo.nombreModelo,
                           anio = carro.anio,
                           nombreRepuesto = repuesto.nombreRepuesto,
                           precio = repuesto.precio
                       };

            List<Inventario> inventarios = list.ToList();

            return inventarios;
        }*/
    }
}
