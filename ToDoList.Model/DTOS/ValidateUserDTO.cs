using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoList.Model.DTOS
{
    public class ValidateUserDTO
    {
        [Required]
        public string Identification { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
