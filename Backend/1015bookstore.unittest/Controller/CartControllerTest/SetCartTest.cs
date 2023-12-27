using _1015bookstore.application.Catalog.Carts;
using _1015bookstore.application.Catalog.Products;
using _1015bookstore.viewmodel.Catalog.Carts;
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

namespace _1015bookstore.unittest.Controller.CartControllerTest
{
    public class SetCartTest
    {
        private Mock<ICartService> _serviceMock;
        private CartController _sut;

        public SetCartTest()
        {
            _serviceMock = new Mock<ICartService>();
            _sut = new CartController(_serviceMock.Object);
        }

        [Theory]
        [InlineData(1, 2, "69BD714F-9576-45BA-B5B7-F00649BE00DE")]
        public async Task SetCart_ShouldReturnStatus200_WhenDataIsValid(int product_id, int amount, string user_id)
        {
            //Arrange
            Guid userid = user_id == null ? Guid.Empty : Guid.Parse(user_id);
            var request = new ProductAdd
            {
                product_id = product_id,
                amount = amount,
            };
            var response = new ResponseService
            {
                CodeStatus = 201,
                Status = true,
            };
            _serviceMock.Setup(x => x.SetProductInCart(request, userid)).ReturnsAsync(response);
            // Act
            var result = await _sut.SetCart(request, userid) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(201);
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData(1, 0, "69BD714F-9576-45BA-B5B7-F00649BE00DE")]
        public async Task SetCart_ShouldReturnStatus400_WhenDataIsInvalid(int product_id, int amount, string user_id)
        {
            //Arrange
            Guid userid = user_id == null ? Guid.Empty : Guid.Parse(user_id);
            var request = new ProductAdd
            {
                product_id = product_id,
                amount = amount,
            };
            _sut.ModelState.AddModelError("Subject", "Wrong");
            // Act
            var result = await _sut.SetCart(request, userid) as BadRequestObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(400);
        }

        [Theory]
        [InlineData(2, 2, "69BD714F-9576-45BA-B5B7-F00649BE00DE")]
        [InlineData(1, 2, "69BD714F-9576-45BA-B5B7-F00649BE00DA")]
        public async Task SetCart_ShouldReturnStatus400_WhenDataIsNotExisted(int product_id, int amount, string user_id)
        {
            //Arrange
            Guid userid = user_id == null ? Guid.Empty : Guid.Parse(user_id);
            var request = new ProductAdd
            {
                product_id = product_id,
                amount = amount,
            };
            var response = new ResponseService
            {
                CodeStatus = 400,
                Status = false,
            };
            _serviceMock.Setup(x => x.SetProductInCart(request, userid)).ReturnsAsync(response);
            // Act
            var result = await _sut.SetCart(request, userid) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(400);
        }

    }
}
