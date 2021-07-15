using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model.Base.Interfaces.Repository;
using ToDoList.Model.DTOS;
using ToDoList.Model.DTOS.Response;
using ToDoList.Model.DTOS.Response.Base;
using ToDoList.Model.MyModels;
using ToDoList.Model.MyModels.Error;
using ToDoList.Model.Repos;
using ToDoList.Model.Services;

namespace ToDoList.Infraestructure.Services
{
    public class ItemCarService : IItemCarService
    {
        private readonly IItemCarRepository _itemCarRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ItemCarService(
            IItemCarRepository itemCarRepository, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _itemCarRepository = itemCarRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public EntityResponse ChangeStateItem(ItemCarDTO itemDTO, int id)
        {
            EntityResponse response = new EntityResponse();

            try
            {
                var item = _itemCarRepository.FindById(id);

                if (item != null)
                {
                    item.IsCompleted = itemDTO.IsCompleted;
                    _unitOfWork.Context.ItemCar.Update(item);
                    _unitOfWork.Commit();

                    response.StatusCode = System.Net.HttpStatusCode.OK;
                    response.Entity = item;
                }
                else
                { 
                    response.Errors = new List<Error>
                    {
                        new Error(System.Net.HttpStatusCode.NotModified,
                        GetType().Name)
                    };
                }
            }
            catch (Exception)
            {
                response.Errors.Add(new Error(System.Net.HttpStatusCode.InternalServerError,
                        GetType().Name));
            }

            return response;
        }

        public CreateEntityResponse CreateItem(ItemCarDTO item)
        {
            CreateEntityResponse response;

            try
            {
                var itemCar = _mapper.Map<ItemCar>(item);

                _itemCarRepository.Add(itemCar);
                _unitOfWork.Commit();

                response = new CreateEntityResponse
                {
                    Entity = item,
                    StatusCode = System.Net.HttpStatusCode.Created,
                    Message = "The resource has been created successfully"
                };

            }
            catch (Exception)
            {
                response = new CreateEntityResponse
                {
                    Errors = new List<Error>
                    {
                        new Error(System.Net.HttpStatusCode.InternalServerError,
                        "An error has ocurred",
                        "ShoppingCarService -> CreateShoppingCar")
                    }
                };
            }

            return response;
        }

        public EntityResponse DeleteItem(int id)
        {
            EntityResponse response = new EntityResponse();

            try
            {
                _itemCarRepository.Delete(id);
                _unitOfWork.Commit();

                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception)
            {
                response.Errors
                    .Add(new Error(System.Net.HttpStatusCode.InternalServerError, "ItemCarService => DeleteItem"));
            }

            return response;
        }

        public EntityResponse UpdateItem(ItemCarDTO item, int id)
        {
            EntityResponse response = new EntityResponse();

            try
            {
                var itemCar = _itemCarRepository.FindById(id);

                if (item != null)
                {
                    itemCar.IsCompleted = item.IsCompleted;
                    itemCar.Amount = item.Amount;
                    itemCar.Name = item.Name;
                    itemCar.ModifiedAt = DateTime.Now;

                    _unitOfWork.Context.ItemCar.Update(itemCar);
                    _unitOfWork.Commit();

                    response.StatusCode = System.Net.HttpStatusCode.OK;
                    response.Entity = item;
                }
                else
                {
                    response.Errors = new List<Error>
                    {
                        new Error(System.Net.HttpStatusCode.NotModified,
                        "ItemCarService => UpdateItem")
                    };
                }
            }
            catch (Exception)
            {
                response.Errors.Add(new Error(System.Net.HttpStatusCode.InternalServerError,
                        "ItemCarService => UpdateItem"));
            }

            return response;
        }
    }
}
