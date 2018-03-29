using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<CheeseCategory> cheeseCategories = context.Categories.ToList();

            return View(cheeseCategories);
        }


        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add new cheese category to existing cheese categories
                CheeseCategory newCategory = new CheeseCategory
                {
                    Name = addCategoryViewModel.Name,


                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category");
            }

            return View(addCategoryViewModel);
        }

       
        public IActionResult ViewCheeses(int ID)
        {
            IList<Cheese> Cheeses = new List<Cheese>();
            CheeseCategory Category = new CheeseCategory();

            Cheeses = context.Cheeses
                .Where(c => c.CategoryId == ID)
                .ToList();

            Category = context.Categories.Single(c => c.ID == ID);
            ViewBag.Title = "Category " + Category.Name + " Cheeses";

            return View(Cheeses);

        }
    }
}
