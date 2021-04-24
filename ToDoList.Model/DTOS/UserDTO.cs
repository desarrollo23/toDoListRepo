using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Model.DTOS
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Identification { get; set; }

        public string Email { get; set; }
    }
}
