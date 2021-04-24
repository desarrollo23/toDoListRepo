using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.Model.Base.Entity;
using ToDoList.Model.Base.Interfaces.Repository;

namespace ToDoList.Infraestructure.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            _unitOfWork.Context.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = _unitOfWork.Context.Set<T>().FirstOrDefault(x => x.Id == id);

            if(entity != null)
            {
                _unitOfWork.Context.Remove(entity);
            }
        }

        public IList<T> FindAll()
        {
            return _unitOfWork.Context.Set<T>().ToList();
        }

        public T FindById(int id)
        {
            return _unitOfWork.Context.Set<T>().FirstOrDefault(x => x.Id == id);
        }
    }
}
