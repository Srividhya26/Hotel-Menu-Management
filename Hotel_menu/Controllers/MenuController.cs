using Hotel_menu.Models;
using Hotel_menu.Repository;
using Hotel_menu.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_menu.Controllers
{
    public class MenuController : Controller
    {
        private readonly IUnitOfWork _work;
        private readonly IMenuRepository _menu;
        private readonly IHostingEnvironment _hosting;
        public MenuController(IUnitOfWork work, IMenuRepository menu,IHostingEnvironment hosting)
        {
            _work = work;
            _menu = menu;
            _hosting = hosting;
        }

        [Authorize]
        public IActionResult Index()
        {
            var menus = _menu.GetAll();
            var test = _work.menus.GetAll();

            return View(menus);
        }

        public IActionResult Details(int id)
        {
            var item = _work.menus.Get(id);

            if(item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel create)
        {
            if(ModelState.IsValid)
            {
                string fileName = null;
                if(create.Photo != null)
                {
                    string uploadPhoto = Path.Combine(_hosting.WebRootPath, "images");
                    fileName = Guid.NewGuid().ToString() + "_" + create.Photo.FileName;
                    string filePath = Path.Combine(uploadPhoto, fileName);
                    create.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Menu newMenu = new Menu
                {
                    DishName = create.DishName,
                    Category = create.Category,
                    Description = create.Description,
                    Photo = fileName
                };

                _menu.Add(newMenu);
                _work.save();
                return RedirectToAction("Index", "Menu");
            }

            return View();
        }
    }
}

//new { id = newMenu.Id }