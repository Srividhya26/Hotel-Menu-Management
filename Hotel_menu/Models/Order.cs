using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_menu.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        [Phone]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public double TotalCost { get; set; }
        public int Quantity { get; set; }
        public ICollection<Menu> menus { get; set; }
    }
}
