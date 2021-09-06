using Hotel_menu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_menu.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public IEnumerable<Menu> Menu;
        public Order Order;
    }
}
