using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Administrators
{
    public class DeleteAdministrator
    {
        public class Ejecuta : IRequest {
            public int administradorId { get; set; }
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
                if (administrador == null) {
                    throw new Exception("El administrador solicitado no existe.");
                }

                _context.Remove(administrador);
                var result = await _context.SaveChangesAsync();

                if(result > 0) {
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar al administrador");
            }
        }
    }
}