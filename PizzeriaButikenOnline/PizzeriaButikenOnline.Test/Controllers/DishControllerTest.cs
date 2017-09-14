using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PizzeriaButikenOnline.Controllers;
using PizzeriaButikenOnline.Core;
using PizzeriaButikenOnline.Core.Repositories;

namespace PizzeriaButikenOnline.Test.Controllers
{
    [TestClass]
    public class DishControllerTest
    {
        private readonly DishController _controller;

        public DishControllerTest()
        {
            var mockRepository = new Mock<IDishRepository>();
            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Dishes).Returns(mockRepository.Object);

            var mockMapper = new Mock<IMapper>();
            _controller = new DishController(mockMapper.Object, mockUoW.Object);
        }

        [TestMethod]
        public void Delete_NoDishWithGivenIdExists_ShouldReturnNotFound()
        {
            _controller.Delete(1).Should().BeOfType<NotFoundResult>();
        }
    }
}
