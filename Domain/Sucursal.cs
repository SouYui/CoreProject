using System.Collections.Generic;
namespace Domain
{
    public class Sucursal
    {
        public int sucursalId { get; set; }
        public string nombreSucursal { get; set; }
        public int administradorId { get; set; }
        public Administrador Administrador { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public bool activa { get; set; }
        public ICollection<Inventario> Inventarios { get; set; }
    }
}