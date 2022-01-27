using System.Collections.Generic;
namespace Domain
{
    public class Proveedor
    {
        public int proveedorId { get; set; }
        public string nombre { get; set; }
        public string telefonoFijo { get; set; }
        public string telefonoMovil { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string rfc { get; set; }
        public string clabe { get; set; }
        public string cuenta { get; set; }
        public ICollection<Inventario> ProductoInventario { get; set; }
    }
}