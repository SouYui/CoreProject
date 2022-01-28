using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class Usuario : IdentityUser
    {
        public int usuarioId { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public ICollection<Venta> Compras { get; set; }
    }
}