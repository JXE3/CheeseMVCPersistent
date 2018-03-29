using CheeseMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class ViewCheesesViewModel
    {
        public IList<Cheese> Cheeses { get; set; }
    //    public CheeseCategory Category { get; set; }
    }
}
