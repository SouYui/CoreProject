using System.ComponentModel;
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Administrators
{
    public class EditAdministrator
    {
        public class Ejecuta : IRequest {
            public int administradorId { get; set; }
            public string nombre { get; set; }
            public bool? active { get; set; }
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
                    throw new Exception("El administrador solicitado no existe.");
                }

                administrador.nombre = request.nombre ?? administrador.nombre;
                administrador.active = request.active ?? administrador.active;

                var result = await _context.SaveChangesAsync();

                if(result > 0) {
                    return Unit.Value;
                }

                throw new Exception("No se pudo editar el administrador.");
            }
        }
    }
}