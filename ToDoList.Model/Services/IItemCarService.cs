using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model.DTOS;
using ToDoList.Model.DTOS.Response;
using ToDoList.Model.DTOS.Response.Base;

namespace ToDoList.Model.Services
{
    public interface IItemCarService
    {
        CreateEntityResponse CreateItem(ItemCarDTO item);
        EntityResponse ChangeStateItem(ItemCarDTO item, int id);

        EntityResponse DeleteItem(int id);

        EntityResponse UpdateItem(ItemCarDTO item, int id);
    }
}
