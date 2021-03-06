using System.ComponentModel;
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using FluentValidation;
using Application.ManejadorError;
using System.Net;

namespace Application.Administrators
{
    public class EditAdministrator
    {
        public class Ejecuta : IRequest {
            public int administradorId { get; set; }
            public string nombre { get; set; }
            public bool? active { get; set; }
        }

        public class EjecutaValida : AbstractValidator<Ejecuta> {
            public EjecutaValida() {
                RuleFor( x => x.nombre ).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly BellotaContext _context;

            public Manejador(BellotaContext context) {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var administrador = await _context.Administrador.FindAsync(request.administradorId);
                if(administrador == null) {
                    throw new ErrorHandler(HttpStatusCode.NotFound, new { message = "No se encontrĂ³ al administrador." });
                }

                administrador.nombre = request.nombre ?? administrador.nombre;
                administrador.active = request.active ?? administrador.active;

                var result = await _context.SaveChangesAsync();

                if(result > 0) {
                    return Unit.Value;
                }

                throw new ErrorHandler(HttpStatusCode.BadRequest, new { message = "No se pudo editar al administrador" });
            }
        }
    }
}