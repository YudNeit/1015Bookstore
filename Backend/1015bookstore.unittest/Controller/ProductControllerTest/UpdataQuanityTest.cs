using _1015bookstore.application.Catalog.Products;
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
    public class UpdataQuanityTest
    {
        private readonly Mock<IProductService> _serviceMock;
        private readonly ProductController _sut;

        public UpdataQuanityTest()
        {
            _serviceMock = new Mock<IProductService>();
            _sut = new ProductController(_serviceMock.Object);
        }

        [Theory]
        [InlineData(200)]
        [InlineData(-1)]
        public async Task UpdateQuantity_ShouldReturnStatus200_WhenDataIsValid(int addquantity)
        {
            //Arrange
            var response = new ResponseService
            {
                CodeStatus = 200,
                Status = true,
            };
            _serviceMock.Setup(x => x.UpdataQuanity(1, addquantity)).ReturnsAsync(response);
            // Act
            var result = await _sut.UpdateQuanity(1, addquantity) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData(null)]
        public async Task UpdateQuantity_ShouldReturnStatus400_WhenDataIsInvalid(int addquantity)
        {
            //Arrange
            _sut.ModelState.AddModelError("Subject", "Wrong");
            // Act
            var result = await _sut.UpdateQuanity(1, addquantity) as BadRequestObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(400);
        }

        [Theory]
        [InlineData(-2)]
        public async Task UpdateQuantity_ShouldReturnStatus400_WhenProductOOS(int addquantity)
        {
            //Arrange
            var response = new ResponseService
            {
                CodeStatus = 400,
                Status = false,
            };
            _serviceMock.Setup(x => x.UpdataQuanity(1, addquantity)).ReturnsAsync(response);
            // Act
            var result = await _sut.UpdateQuanity(1, addquantity) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(400);
        }
    }
}
