using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_menu.ViewModel
{
    public class CreateViewModel
    {
        public string DishName { get; set; }
        public IFormFile Photo { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
