using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.Core.BusinessLayer;
using Restaurant.MVC.Helpers;
using Restaurant.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.MVC.Controllers
{
    public class DishesController : Controller
    {
        private readonly IBusinessLayer BL;

        public DishesController(IBusinessLayer BL)
        {
            this.BL = BL;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var dishes = BL.FetchDishes();

            List<DishViewModel> dishesViewModel = new List<DishViewModel>();

            foreach (var item in dishes)
            {
                dishesViewModel.Add(item.ToDishViewModel());
            }

            return View(dishesViewModel);
        }


        [Authorize(Policy = "Manager")]
        [HttpGet]
        public IActionResult Create()
        {
            LoadViewBag();
            return View();
        }

        [Authorize(Policy = "Manager")]
        [HttpPost]
        public IActionResult Create(DishViewModel dishViewModel)
        {
            if (ModelState.IsValid)
            {
                var dish = dishViewModel.ToDish();
                BL.AddNewDish(dish);
                return RedirectToAction(nameof(Index));
            }
            return View(dishViewModel);
        }

        [Authorize(Policy = "Manager")]
        [HttpGet("Dishes/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var dish = BL.FetchDishes().FirstOrDefault(d => d.Id == id);
            var dishViewModel = dish.ToDishViewModel();
            LoadViewBag();
            return View(dishViewModel);
        }


        [Authorize(Policy = "Manager")]
        [HttpPost("Dishes/Edit/{id}")]
        public IActionResult Edit(DishViewModel dishViewModel)
        {
            if (ModelState.IsValid)
            {
                var dish = dishViewModel.ToDish();
                BL.EditDish(dish);
                return RedirectToAction(nameof(Index));
            }
            LoadViewBag();
            return View(dishViewModel);
        }


        [Authorize(Policy = "Manager")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dish = BL.FetchDishes().FirstOrDefault(d => d.Id == id);
            var dishViewModel = dish.ToDishViewModel();
            LoadViewBag();
            return View(dishViewModel);
        }

        [Authorize(Policy = "Manager")]
        [HttpPost]
        public IActionResult Delete(DishViewModel dishViewModel)
        {
            if (ModelState.IsValid)
            {
                var dish = dishViewModel.ToDish();
                BL.DeleteDish(dish.Id);
                return RedirectToAction(nameof(Index));

            }
            return View(dishViewModel);
        }



        private void LoadViewBag()
        {
            ViewBag.Categories = new SelectList(new[]{
                "FirstCourse",
                "SecondCourse",
                "Side",
                "Dessert"
            });

        }
    }
}
