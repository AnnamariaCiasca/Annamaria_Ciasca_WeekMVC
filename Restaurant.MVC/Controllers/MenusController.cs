using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.BusinessLayer;
using Restaurant.MVC.Helpers;
using Restaurant.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.MVC.Controllers
{
    public class MenusController : Controller
    {
        private readonly IBusinessLayer BL;

        public MenusController(IBusinessLayer BL)
        {
            this.BL = BL;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var menus = BL.FetchMenu();

            List<MenùViewModel> menusViewModel = new List<MenùViewModel>();

            foreach (var item in menus)
            {
                menusViewModel.Add(item.ToMenùViewModel());
            }

            return View(menusViewModel);
        }


        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return View("Index");
            }
            var menu = BL.GetMenuById(id);

            var menuViewModel = menu.ToMenùViewModel();
            return View(menuViewModel);
        }


        [Authorize(Policy = "Manager")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "Manager")]
        [HttpPost]
        public IActionResult Create(MenùViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                var menu = menuViewModel.ToMenù();
                BL.AddNewMenu(menu);
                return RedirectToAction(nameof(Index));
            }
            return View(menuViewModel);
        }

        [Authorize(Policy = "Manager")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var menu = BL.FetchMenu().FirstOrDefault(m => m.Id == id);
            var menuViewModel = menu.ToMenùViewModel();
            return View(menuViewModel);
        }


        [Authorize(Policy = "Manager")]
        [HttpPost]
        public IActionResult Edit(MenùViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                var menu = menuViewModel.ToMenù();
                BL.EditMenu(menu);
                return RedirectToAction(nameof(Index));
            }

            return View(menuViewModel);
        }


        [Authorize(Policy = "Manager")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var menu = BL.FetchMenu().FirstOrDefault(m => m.Id == id);
            var menuViewModel = menu.ToMenùViewModel();
            return View(menuViewModel);
        }

        [Authorize(Policy = "Manager")]
        [HttpPost]
        public IActionResult Delete(MenùViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                var menu = menuViewModel.ToMenù();
                BL.DeleteMenu(menu.Id);
                return RedirectToAction(nameof(Index));

            }
            return View(menuViewModel);
        }
    }
}