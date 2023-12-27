using _1015bookstore.application.Catalog.Products;
using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Comon;
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
    public class UpdatePriceTest
    {
        private readonly Mock<IProductService> _serviceMock;
        private readonly ProductController _sut;

        public UpdatePriceTest()
        {
            _serviceMock = new Mock<IProductService>();
            _sut = new ProductController(_serviceMock.Object);
        }

        [Theory]
        [InlineData(300000)]
        public async Task UpdatePrice_ShouldReturnStatus200_WhenDataIsValid(decimal price)
        {
            //Arrange
            var response = new ResponseService
            {
                CodeStatus = 200,
                Status = true,
            };
            _serviceMock.Setup(x => x.UpdatePrice(1 , price)).ReturnsAsync(response);
            // Act
            var result = await _sut.UpdatePrice(1, price) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(-1)]
        public async Task UpdatePrice_ShouldReturnStatus400_WhenDataIsInvalid(decimal price)
        {
            //Arrange
            _sut.ModelState.AddModelError("Subject", "Wrong");
            // Act
            var result = await _sut.UpdatePrice(1, price) as BadRequestObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(400);
        }

    }
}
