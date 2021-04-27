using Microsoft.EntityFrameworkCore;
using ToDoList.Model.MyModels;

namespace ToDoList.Model.Base.Context
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            :base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<ShoppingCar> ShoppingCar { get; set; }

        public DbSet<ItemCar> ItemCar { get; set; }
    }
}
