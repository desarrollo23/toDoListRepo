using System.Collections.Generic;

namespace ToDoList.Model.Base.Interfaces.Repository
{
    public interface IRepository<T> 
    {
        void Add(T entity);
        IList<T> FindAll();

        void Delete(int id);

        T FindById(int id);
    }
}
