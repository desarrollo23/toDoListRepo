using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ToDoList.Model.Base.Entity;

namespace ToDoList.Model.MyModels
{
    public class User: Entity
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public string Identification { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public List<ShoppingCar> ShoppingCars { get; set; }

    }
}
