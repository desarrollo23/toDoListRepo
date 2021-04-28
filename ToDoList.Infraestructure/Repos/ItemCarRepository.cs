using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Infraestructure.Repository;
using ToDoList.Model.Base.Interfaces.Repository;
using ToDoList.Model.MyModels;
using ToDoList.Model.Repos;

namespace ToDoList.Infraestructure.Repos
{
    public class ItemCarRepository: Repository<ItemCar>, IItemCarRepository
    {
        public ItemCarRepository(IUnitOfWork unitOfWork): base(unitOfWork)
        {

        }
    }
}
