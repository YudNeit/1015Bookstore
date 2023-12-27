using _1015bookstore.application.Catalog.Products;
using _1015bookstore.application.System.Users;
using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Users;
using _1015bookstore.webapi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.unittest.Controller.ProductControllerTest
{
    public class CreateProductTest
    {
        private readonly Mock<IProductService> _serviceMock;
        private readonly ProductController _sut;

        public CreateProductTest()
        {
            _serviceMock = new Mock<IProductService>();
            _sut = new ProductController(_serviceMock.Object);
        }

        [Theory]
        [InlineData("Cook Book of Japanese", 300000, 2, 200, "This book for family")]
        public async Task CreateProduct_ShouldReturnStatus201_WhenDataIsValid(string name, decimal price, int waranty, int quantity, string description)
        {
            //Arrange
            var request = new ProductCreateRequest
            {
                name = name,
                price = price,
                waranty = waranty,
                quanity = quantity,
                description = description
            };
            var response = new ResponseService<ProductViewModel>
            {
                CodeStatus = 201,
                Status = true,
            };
            _serviceMock.Setup(x => x.Create(request)).ReturnsAsync(response);
            // Act
            var result = await _sut.Create(request) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(201);
        }

        [Theory]
        [InlineData(null, null, null, null, null)]
        [InlineData("Cook Book of Japanese", -1, 0, 0, "This book for family")]
        public async Task CreateProduct_ShouldReturnStatus400_WhenDataIsInvalid(string name, decimal price, int waranty, int quantity, string description)
        {
            //Arrange
            var request = new ProductCreateRequest
            {
                name = name,
                price = price,
                waranty = waranty,
                quanity = quantity,
                description = description
            };
            var response = new ResponseService<ProductViewModel>
            {
                CodeStatus = 400,
                Status = false,
            };
            _sut.ModelState.AddModelError("Subject", "Wrong");
            // Act
            var result = await _sut.Create(request) as BadRequestObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(400);
        }
    }
}
