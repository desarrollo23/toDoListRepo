using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using ToDoList.Infraestructure.Services;
using ToDoList.Model.Base.Interfaces.Repository;
using ToDoList.Model.DTOS.Response.Base;
using ToDoList.Model.MyModels;
using ToDoList.Model.Repos;
using ToDoList.Model.Services;

namespace ToDoList.Test.Services
{
    [TestClass]
    public class ShoppingCartServiceTest
    {
        [TestInitialize]
        public void Init()
        {

        }

        [TestMethod]
        public void ValidateReturnShoppingCarIsNotNull()
        {

            
            // Arrange
            var IShoppingCarRepositoryMock = new Mock<IShoppingCarRepository>();
            var IMapperMock = new Mock<IMapper>();
            var IUnitOfWorkMock = new Mock<IUnitOfWork>();


            int id = 10;

           
            var car = new ShoppingCar
            {
                UserId = 2,
                Description = "Lista de cosas que necesitamos para abril",
                Name = "Mercado abril",
                Id = 10,
                Items = null,
                CreatedAt = new DateTime(2021, 5, 07, 16, 12, 25),
                ModifiedAt = new DateTime(2021, 5, 07, 16, 12, 25)
            };


            IShoppingCarRepositoryMock.Setup(x => x.FindById(id))
                .Returns(car);


            var ShoppingCarService =
                new ShoppingCarService(IShoppingCarRepositoryMock.Object, IMapperMock.Object, IUnitOfWorkMock.Object, null);


            var result = ShoppingCarService.GetShoppingCartById(id);

            Assert.IsNotNull(result);


        }

        [TestMethod]
        public void ValidateReturnShoppingCarWithErrors()
        {
            var IShoppingCarRepositoryMock = new Mock<IShoppingCarRepository>();
            var IMapperMock = new Mock<IMapper>();
            var IUnitOfWorkMock = new Mock<IUnitOfWork>();

            ShoppingCar car = null;

            int id = 18;

            IShoppingCarRepositoryMock.Setup(x => x.FindById(id))
                .Returns(car);


            var ShoppingCarService =
                new ShoppingCarService(IShoppingCarRepositoryMock.Object, IMapperMock.Object, IUnitOfWorkMock.Object, null);


            var result = ShoppingCarService.GetShoppingCartById(id);

            Assert.IsTrue(result.Errors.Count > 0, result.Errors.Select(x => x.Message).FirstOrDefault());
        }
    }
}
