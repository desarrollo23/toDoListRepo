using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model.Base.Entity;

namespace ToDoList.Model.MyModels
{
    public class ShoppingCar: Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public List<ItemCar> Items { get; set; }
    }
}
