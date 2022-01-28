using System.Collections.Generic;
using System;
namespace Domain
{
    public class Menu
    {
        public int menuId { get; set; }
        public DateTime inicioTemporada { get; set; }
        public DateTime finTemporada { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}