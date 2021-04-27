using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model.DTOS
{
    public class ShoppingCarDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }


        [Required]
        public int UserId { get; set; }
    }
}
