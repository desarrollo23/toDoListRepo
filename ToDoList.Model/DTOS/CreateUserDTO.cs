using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Model.Base.Entity;

namespace ToDoList.Model.DTOS
{
    public class CreateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Identification { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
