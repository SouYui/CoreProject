using System.Collections.Generic;
namespace Domain
{
    public class Venta
    {
        public int ventaId { get; set; }
        public int usuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public float costo { get; set; }
        public ICollection<ProductoVenta> ProductoVentas { get; set; }
    }
}