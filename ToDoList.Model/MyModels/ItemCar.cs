using ToDoList.Model.Base.Entity;

namespace ToDoList.Model.MyModels
{
    public class ItemCar: Entity
    {
        public string Name { get; set; }
        public int Amount { get; set; }

        public int ShoppingCarId { get; set; }

        public ShoppingCar ShoppingCar { get; set; }

        public bool IsCompleted { get; set; }
    }
}
