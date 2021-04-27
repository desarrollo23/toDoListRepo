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
                .Where(x => x.UserId == idUser)
                // .Include(x => x.User)
                .Include(x => x.Items)
                .ToList();
        }
    }
}
