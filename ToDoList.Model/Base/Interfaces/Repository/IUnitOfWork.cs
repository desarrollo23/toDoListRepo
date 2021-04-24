using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Model.Base.Context;

namespace ToDoList.Model.Base.Interfaces.Repository
{
    public interface IUnitOfWork: IDisposable
    {
        MyDbContext Context { get; }
        void Commit();
    }
}
