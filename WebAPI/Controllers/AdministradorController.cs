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

    }
}