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
            //var menus = _menu.GetAll();
            var test = _work.menus.GetAll();

            return View(test);
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
                string fileName = UploadedFile(create);

                Menu newMenu = new Menu
                {
                    DishName = create.DishName,
                    Category = create.Category,
                    Description = create.Description,
                    Price = create.Price,
                    Photo = fileName
                };

                _menu.Add(newMenu);
                _work.save();
                return RedirectToAction("Index", "Menu");
            }

            return View();
        }

        public IActionResult Update(int id)
        {
            Menu menu = _menu.Get(id);
            UpdateViewModel update = new UpdateViewModel
            {
                Id = menu.Id,
                DishName = menu.DishName,
                Category = menu.Category,
                Description = menu.Description,
                Price = menu.Price,
                ExistingPhotoPath = menu.Photo
            };
            return View(update);
        }

        [HttpPost]
        public IActionResult Update(UpdateViewModel edit)
        {
            if (ModelState.IsValid)
            {
                Menu menu = _menu.Get(edit.Id);
                menu.DishName = edit.DishName;
                menu.Category = edit.Category;
                menu.Description = edit.Description;
                menu.Price = edit.Price;
                if(edit.Photo != null)
                {
                    menu.Photo = UploadedFile(edit);
                }
               
                _menu.Update(menu);
                _work.save();
                return RedirectToAction("Index");
            }

            return View();
        }

        private string UploadedFile(CreateViewModel edit)
        {
            string fileName = null;
            if (edit.Photo != null)
            {
                string uploadPhoto = Path.Combine(_hosting.WebRootPath, "images");
                fileName = Guid.NewGuid().ToString() + "_" + edit.Photo.FileName;
                string filePath = Path.Combine(uploadPhoto, fileName);
                edit.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            return fileName;
        }

        public IActionResult Delete(int id)
        {
            var item = _work.menus.Get(id);

            if(item == null)
            {
                return NotFound();
            }

            _work.menus.Remove(item);
            _work.save();

            return RedirectToAction("Index");
        }
    }
}

