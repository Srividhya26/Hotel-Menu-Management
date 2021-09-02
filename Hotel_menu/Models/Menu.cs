using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_menu.Models
{
    public class Menu
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter the Dish Name")]
        public string DishName { get; set; }
        [Required(ErrorMessage ="Give Description")]
        [MaxLength(250,ErrorMessage ="The description should be less than 250 words")]
        public string Description { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required(ErrorMessage ="Please enter the category")]
        public string Category { get; set; }
        public double Price { get; set; }
    }
}
