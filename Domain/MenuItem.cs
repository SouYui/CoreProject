namespace Domain
{
    public class MenuItem
    {
        public int itemId { get; set; }
        public int menuId { get; set; }
        public Menu Menu { get; set; }
        public int productoId { get; set; }
        public Producto Producto { get; set; }
    }
}