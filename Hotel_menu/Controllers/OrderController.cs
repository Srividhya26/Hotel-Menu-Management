using Hotel_menu.Models;
using Hotel_menu.Repository;
using Hotel_menu.ViewModel;
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
        private readonly IOrderRepository _order;

        public OrderController(IUnitOfWork work, IMenuRepository menu,IOrderRepository order)
        {
            _work = work;
            _menu = menu;
            _order = order;
        }
        public IActionResult Index()
        {
            //var orders = _menu.GetAll();
            var test = _work.menus.GetAll();

            return View(test);
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

        [HttpPost]
        public IActionResult Item(Order order)
        {
            if (ModelState.IsValid)
            {

                //Order newOrder = new Order
                //{
                //    Name = order.Name,
                //    PhoneNumber = order.PhoneNumber,
                //    Quantity = order.Quantity

                //};

                _order.Add(order);
                _work.save();
                return RedirectToAction("Index", "Order");
            }

            return View();
        }
    }
}
