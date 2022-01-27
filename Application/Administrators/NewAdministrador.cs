using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Administrators
{
    public class NewAdministrador
    {
        public class Ejecuta : IRequest {
            //[Required(ErrorMessage="Por favor ingrese el nombre del administrador.")]
            public string nombre { get; set; }
            public bool active { get; set; }
        }

        public class EjecutaValida : AbstractValidator<Ejecuta> {
            public EjecutaValida() {
                RuleFor( x => x.nombre ).NotEmpty();
                RuleFor( x => x.active ).NotEmpty();
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