using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model.DTOS
{
    public class ItemCarDTO
    {
        public string Name { get; set; }
        public int Amount { get; set; }

        public int ShoppingCarId { get; set; }

        public bool IsCompleted { get; set; }
    }
}
