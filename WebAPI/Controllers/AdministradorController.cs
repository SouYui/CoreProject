using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Administrators;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    // http://localhost:5000/api/Administrador
    [ApiController]
    [Route("api/[controller]")]
    public class AdministradorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdministradorController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Administrador>>> Get() {
            return await _mediator.Send(new GetAdministrador.ListaAdministradores());
        }

        // http://localhost:5000/api/Administrador/9
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetAdministrador(int id) {
            return await _mediator.Send(new GetAdministradorId.Ejecuta{ administradorId = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CrearAdministrador(NewAdministrador.Ejecuta data) {
            return await _mediator.Send(data);
        }

    }
}