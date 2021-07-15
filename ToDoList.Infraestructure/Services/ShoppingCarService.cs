using AutoMapper;
using System;
using System.Collections.Generic;
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
    public class ShoppingCarService : IShoppingCarService
    {
        private readonly IMapper _mapper;
        private readonly IShoppingCarRepository _shoppingCarRepository;
        private readonly IItemCarRepository _itemCarRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCarService(IShoppingCarRepository shoppingCarRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IItemCarRepository itemCarRepository)
        {
            _mapper = mapper;
            _shoppingCarRepository = shoppingCarRepository;
            _unitOfWork = unitOfWork;
            _itemCarRepository = itemCarRepository;
        }

        public CreateEntityResponse CreateShoppingCar(ShoppingCarDTO shoppingCarDTO)
        {
            CreateEntityResponse createEntityResponse
                = new CreateEntityResponse();

            try
            {
                var shoppingCar = _mapper.Map<ShoppingCar>(shoppingCarDTO);

                _shoppingCarRepository.Add(shoppingCar);
                _unitOfWork.Commit();

                createEntityResponse.Entity = shoppingCarDTO;
                createEntityResponse.StatusCode = System.Net.HttpStatusCode.Created;
                createEntityResponse.Message = "The resource has been created successfully";

            }
            catch (Exception)
            {
                createEntityResponse.Errors.Add(new Error(System.Net.HttpStatusCode.InternalServerError,
                        "ShoppingCarService -> CreateShoppingCar"));
            }

            return createEntityResponse;
        }

        public EntityResponse DeleteShoppingCar(int id)
        {
            EntityResponse response = new EntityResponse();

            try
            {
                var shoppingCar = _shoppingCarRepository.FindById(id);
                var items = shoppingCar.Items;

                if(items.Count > 0)
                    _unitOfWork.Context.ItemCar.RemoveRange(items);

                _shoppingCarRepository.Delete(id);
                _unitOfWork.Commit();

                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception)
            {
                response.Errors
                    .Add(new Error(System.Net.HttpStatusCode.InternalServerError, 
                    "ShoppingCarService => DeleteShoppingCar"));
            }

            return response;
        }

        public EntityResponse GetShoppingCarsByIdUser(int idUser)
        {
            var response = new EntityResponse();
            var shoppingCars = _shoppingCarRepository.GetShoppingCarsByIdUser(idUser);

            if (shoppingCars.Count > 0)
            {
                response.Entity = shoppingCars;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }

            return response;
        }

        public EntityResponse GetShoppingCartById(int id)
        {
            EntityResponse response;

            try
            {
                var cart = _shoppingCarRepository.FindById(id);

                if(cart != null)
                {
                    response = new EntityResponse
                    {
                        Entity = cart,
                        StatusCode = System.Net.HttpStatusCode.OK
                    };
                }
                else
                {
                    response = new EntityResponse
                    {
                        Errors = new List<Error>
                        {
                            new Error(System.Net.HttpStatusCode.NotFound, "GetShoppingCartById")
                        }
                    };
                }
            }
            catch (Exception)
            {
                response = new EntityResponse
                {
                    Errors = new List<Error>
                        {
                            new Error(System.Net.HttpStatusCode.InternalServerError, "GetShoppingCartById")
                        }
                };
            }

            return response;
        }

        public EntityResponse UpdateShoppingCar(ShoppingCarDTO shoppingCarDTO, int id)
        {
            EntityResponse response = new EntityResponse();

            try
            {
                var shoppingCar = _shoppingCarRepository.FindById(id);

                if (shoppingCar != null)
                {
                    shoppingCar.Name = shoppingCarDTO.Name;
                    shoppingCar.Description = shoppingCarDTO.Description;
                    shoppingCar.ModifiedAt = DateTime.Now;

                    _unitOfWork.Context.ShoppingCar.Update(shoppingCar);
                    _unitOfWork.Commit();

                    response.StatusCode = System.Net.HttpStatusCode.OK;
                    response.Entity = shoppingCarDTO;
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
                        "ShoppingCarService => UpdateShoppingCar"));
            }

            return response;
        }
    }
}
