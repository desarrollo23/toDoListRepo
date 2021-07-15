using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model.DTOS;
using ToDoList.Model.DTOS.Response;
using ToDoList.Model.DTOS.Response.Base;
using ToDoList.Model.MyModels;

namespace ToDoList.Model.Services
{
    public interface IShoppingCarService
    {
        CreateEntityResponse CreateShoppingCar(ShoppingCarDTO shoppingCarDTO);

        EntityResponse GetShoppingCarsByIdUser(int idUser);

        EntityResponse UpdateShoppingCar(ShoppingCarDTO shoppingCarDTO, int id);

        EntityResponse DeleteShoppingCar(int id);

        EntityResponse GetShoppingCartById(int id);

    }
}
