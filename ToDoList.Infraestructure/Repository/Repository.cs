using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.Model.Base.Context;
using ToDoList.Model.Base.Entity;
using ToDoList.Model.Base.Interfaces.Repository;

namespace ToDoList.Infraestructure.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private MyDbContext _context;

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().FirstOrDefault(x => x.Id == id);

            if(entity != null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        public IList<T> FindAll()
        {
            return _context.Set<T>().ToList();
        }

        public T FindById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }
    }
}
