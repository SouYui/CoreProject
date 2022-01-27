using System.Collections;
using System.Collections.Generic;
namespace Domain
{
    public class Administrador
    {
        public int administradorId { get; set; }
        public string nombre { get; set; }
        public bool active { get; set; }
        public ICollection<Sucursal> Sucursales { get; set; }
        public ICollection<Inventario> InventariosAutorizados { get; set; }
    }
}