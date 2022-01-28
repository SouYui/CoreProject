namespace Domain
{
    public class ProductoVenta
    {
        public int prdVentaId { get; set; }
        public int productoId { get; set; }
        public Producto Producto { get; set; }
        public int ventaId { get; set; }
        public Venta Venta { get; set; }
        public int cantidad { get; set; }
        public int monto { get; set; }
    }
}