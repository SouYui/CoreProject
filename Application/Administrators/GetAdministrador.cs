using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Administrators
{
    public class GetAdministrador 
    {
        public class ListaAdministradores : IRequest<List<Administrador>> {}

        public class Manejador : IRequestHandler<ListaAdministradores, List<Administrador>>
        {
            private readonly BellotaContext _context;

            public Manejador(BellotaContext context) {
                _context = context;
            }

            public async Task<List<Administrador>> Handle(ListaAdministradores request, CancellationToken cancellationToken)
            {
                var administradores = await _context.Administrador.ToListAsync();
                return administradores;
            }
        }
    }
}