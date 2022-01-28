using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.ManejadorError;
using Domain;
using MediatR;
using Persistence;

namespace Application.Administrators
{
    public class GetAdministradorId
    {
        public class Ejecuta : IRequest<Administrador> {
            public int administradorId { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, Administrador>
        {
            private readonly BellotaContext _context;
            
            public Manejador(BellotaContext context) {
                _context = context;
            }

            public async Task<Administrador> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var administrador = await _context.Administrador.FindAsync(request.administradorId);
                if(administrador == null) {
                    throw new ErrorHandler(HttpStatusCode.NotFound, new { message = "No se encontró al administrador." });
                }
                
                return administrador;
            }
        }
    }
}