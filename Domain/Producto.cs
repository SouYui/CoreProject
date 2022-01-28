using System.Collections.Generic;
using System;
namespace Domain
{
    public class Producto
    {
        public int productoId { get; set; }
        public string nombre { get; set; }
        public float precio { get; set; }
        public int exhibicionId { get; set; }
        public AreasExhibicion AreasExhibicion { get; set; }
        public DateTime fechaCaducidad { get; set; }
        public int proveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
        public ICollection<ProductoVenta> ProductoVentas { get; set; }
    }
}