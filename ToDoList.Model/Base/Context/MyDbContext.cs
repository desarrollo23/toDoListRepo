using Microsoft.EntityFrameworkCore;

namespace ToDoList.Model.Base.Context
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            :base(options)
        {

        }

        public DbSet<User.User> User { get; set; }
    }
}
