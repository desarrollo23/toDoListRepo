using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Model.Base.Context;
using ToDoList.Model.Base.Entity;
using ToDoList.Model.Base.Interfaces.Repository;

namespace ToDoList.Infraestructure.Repository
{
    public class UnitOfWork : IUnitOfWork 
    {
        public MyDbContext Context { get;  }

        public UnitOfWork(MyDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
