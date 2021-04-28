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
    public class ItemCarProfile: Profile
    {
        public ItemCarProfile()
        {
            CreateMap<ItemCarDTO, ItemCar>().ReverseMap();
        }
    }
}
