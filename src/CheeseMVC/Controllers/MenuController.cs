using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly CheeseDbContext context;

        public MenuController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Menu> menus = context.Menus.ToList();
            return View(menus);
        }

        public IActionResult Add()
        {
            AddMenuViewModel addMenuViewModel = new AddMenuViewModel();
            return View(addMenuViewModel);

        }

        [HttpPost]
        public IActionResult Add(AddMenuViewModel addMenuViewModel)
        {
            if (ModelState.IsValid)
            {
                Menu newMenu = new Menu
                {
                    Name = addMenuViewModel.Name
                };

                context.Menus.Add(newMenu);
                context.SaveChanges();

                return Redirect("/Menu");
            }

            return View();
            // return View(addMenuViewModel);
            // return Redirect("/Menu/ViewMenu/" + newMenu.ID)
        }

        

        public IActionResult ViewMenu(int id)
        {
 
            List<CheeseMenu> items = context
                .CheeseMenu
                .Include(item => item.Cheese)
                .Where(cm => cm.MenuID == id)
                .ToList();

            Menu menu = context.Menus.Single(m => m.ID == id);

        
         

            ViewMenuViewModel viewModel = new ViewMenuViewModel
        
            {
                Menu = menu,
                Items = items
            };

                       
            return View(viewModel);


           
        }


       
        public IActionResult AddItem(int ID, string msg)
        {
           
            
            List<SelectListItem> cheeses = new List<SelectListItem>();

            IEnumerable<Cheese> allCheeses = context.Cheeses.ToList();

            foreach (Cheese cheese in allCheeses)
            {
                cheeses.Add(new SelectListItem
                {
                    Value = cheese.ID.ToString(),
                    Text = cheese.Name
                });
            }

            Menu menu = context.Menus.Single(m => m.ID == ID);

            AddMenuItemViewModel addMenuItemViewModel = new AddMenuItemViewModel(menu, cheeses);

            ViewBag.message = msg;

            return View(addMenuItemViewModel);

        }

        public IActionResult AddItem2(AddMenuItemViewModel addMenuItemViewModel)
        {
            var cheeseId = addMenuItemViewModel.CheeseID;
            var menuID = addMenuItemViewModel.MenuID;

            IList<CheeseMenu> existingItems = context.CheeseMenu
                .Where(CheeseMenu => CheeseMenu.CheeseID == cheeseId)
                .Where(CheeseMenu => CheeseMenu.MenuID == menuID).ToList();

            if (existingItems.Count == 0)
            {
                CheeseMenu menuItem = new CheeseMenu
                {
                    Cheese = context.Cheeses.Single(c => c.ID == cheeseId),
                    Menu   = context.Menus.Single(m => m.ID == menuID)
                };

                context.CheeseMenu.Add(menuItem);
                context.SaveChanges();
            }
            else
            {
                
                return Redirect(string.Format("AddItem/{0}?msg={1}", addMenuItemViewModel.MenuID, "This cheese is already on menu"));
                // return Redirect(string.Format("AddItem?id1={0}&id2={1}", addMenuItemViewModel.MenuID, "This cheese is already on menu"));
            }




            return Redirect(string.Format("ViewMenu/{0}", addMenuItemViewModel.MenuID));
            
        }



        }
  
}