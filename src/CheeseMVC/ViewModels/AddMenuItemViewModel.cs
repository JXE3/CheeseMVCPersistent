using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddMenuItemViewModel
    {
        public Menu Menu { get; set; }
        public List<SelectListItem> Cheeses { get; set; }

        public int MenuID { get; set; }
        public int CheeseID { get; set; }

    
        public AddMenuItemViewModel() { }
    
        public AddMenuItemViewModel(Menu menu, List<SelectListItem> cheeses)
        {
            Cheeses = cheeses;

            Menu = menu;

        }

    }
}
