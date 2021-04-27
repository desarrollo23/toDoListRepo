using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model.Base.Interfaces.Repository;
using ToDoList.Model.DTOS.Response.Base;
using ToDoList.Model.MyModels;

namespace ToDoList.Model.Repos
{
    public interface IShoppingCarRepository: IRepository<ShoppingCar>
    {
        List<ShoppingCar> GetShoppingCarsByIdUser(int idUser);
    }
}
