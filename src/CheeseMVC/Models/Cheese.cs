using System.Collections.Generic;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CheeseCategory Category { get; set; }

        public int CategoryId { get; set; }
        
        public int ID { get; set; }

        IList <CheeseMenu> CheeseMenus { get; set; }
        IList <Cheese> Cheeses { get; set; }

    }
}
