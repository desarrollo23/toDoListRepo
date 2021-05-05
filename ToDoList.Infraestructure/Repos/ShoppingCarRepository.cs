using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model.Base.Interfaces.Repository;
using ToDoList.Model.DTOS.Response.Base;
using ToDoList.Model.MyModels;
using ToDoList.Model.Repos;

namespace ToDoList.Infraestructure.Repos
{
    public class ShoppingCarRepository : Repository.Repository<ShoppingCar>, IShoppingCarRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCarRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ShoppingCar> GetShoppingCarsByIdUser(int idUser)
        {
            return _unitOfWork.Context.ShoppingCar
                .Include(x => x.Items)
                .Where(x => x.UserId == idUser)
                .ToList();
        }

        public override ShoppingCar FindById(int id)
        {
            return _unitOfWork.Context.ShoppingCar
                .Include(x => x.Items)
                .FirstOrDefault(x => x.Id == id);
                
        }
    }
}
