using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Administrators
{
    public class NewAdministrador
    {
        public class Ejecuta : IRequest {
            public string nombre { get; set; }
            public bool active { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly BellotaContext _context;

            public Manejador(BellotaContext context) {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var administrador = new Administrador{
                    nombre = request.nombre,
                    active = request.active
                };

                _context.Administrador.Add(administrador);
                var result = await _context.SaveChangesAsync();

                if(result > 0) {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el Administrador");
            }
        }
    }
}