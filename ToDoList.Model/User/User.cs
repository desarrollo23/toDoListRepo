using ToDoList.Model.Base.Entity;

namespace ToDoList.Model.User
{
    public class User: Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }

        public string Email { get; set; }

    }
}
