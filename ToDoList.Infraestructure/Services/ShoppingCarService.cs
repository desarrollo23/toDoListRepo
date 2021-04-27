using AutoMapper;
using System;
using System.Collections.Generic;
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
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCarService(IShoppingCarRepository shoppingCarRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _shoppingCarRepository = shoppingCarRepository;
            _unitOfWork = unitOfWork;
        }

        public CreateEntityResponse CreateShoppingCar(ShoppingCarDTO shoppingCarDTO)
        {
            CreateEntityResponse createEntityResponse;

            try
            {
                var shoppingCar = _mapper.Map<ShoppingCar>(shoppingCarDTO);

                shoppingCar.CreatedAt = DateTime.Now;
                shoppingCar.ModifiedAt = null;

                _shoppingCarRepository.Add(shoppingCar);
                _unitOfWork.Commit();

                createEntityResponse = new CreateEntityResponse
                {
                    Entity = shoppingCarDTO,
                    StatusCode = System.Net.HttpStatusCode.Created,
                    Message = "The shopping car has been created successfully"
                };

            }
            catch (Exception ex)
            {
                createEntityResponse = new CreateEntityResponse
                {
                    Entity = shoppingCarDTO,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Errors = new List<Error>
                    {
                        new Error(System.Net.HttpStatusCode.InternalServerError,
                        ex.Message,
                        "ShoppingCarService -> CreateShoppingCar")
                    }
                };
            }

            return createEntityResponse;
        }

        public EntityResponse GetShoppingCarsByIdUser(int idUser)
        {
            var response = new EntityResponse();
            var shoppingCars = _shoppingCarRepository.GetShoppingCarsByIdUser(idUser);

            if(shoppingCars.Count > 0)
            {
                response.Entity = shoppingCars;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }

            return response;
        }
    }
}
