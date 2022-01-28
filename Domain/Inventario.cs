using System;
namespace Domain
{
    public class Inventario
    {
        public int inventarioId { get; set; }
        public int productoId { get; set; } 
        public Producto Producto { get; set; }
        public int sucursalId { get; set; }
        public Sucursal Sucursal { get; set; }
        public int cantidad { get; set; }
        public DateTime fechaCaducidad { get; set; }
        public DateTime fechaAbastecimiento { get; set; }
        public int proveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
        public DateTime proximoAbastecimiento { get; set; }
        public int proveedorId1 { get; set; }
        public int administradorId { get; set; }
        public Administrador Administrador { get; set; }
    }
}