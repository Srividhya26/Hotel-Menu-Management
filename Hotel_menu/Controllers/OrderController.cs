using Hotel_menu.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_menu.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _work;
        private readonly IMenuRepository _menu;

        public OrderController(IUnitOfWork work, IMenuRepository menu)
        {
            _work = work;
            _menu = menu;           
        }
        public IActionResult Index()
        {
            var menus = _menu.GetAll();
            var test = _work.menus.GetAll();

            return View(menus);
        }

        public IActionResult Details(int id)
        {
            var item = _work.menus.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        public IActionResult Item()
        {
            return View();
        }
    }
}
