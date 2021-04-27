using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model.DTOS;
using ToDoList.Model.MyModels;

namespace ToDoList.Infraestructure.Mappers
{
    public class ShoppingCarProfile: Profile
    {
        public ShoppingCarProfile()
        {
            CreateMap<ShoppingCar, ShoppingCarDTO>().ReverseMap();
        }
    }
}
