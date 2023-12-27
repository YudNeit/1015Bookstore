using _1015bookstore.application.Catalog.Carts;
using _1015bookstore.application.Catalog.Orders;
using _1015bookstore.viewmodel.Catalog.Carts;
using _1015bookstore.viewmodel.Catalog.Orders;
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

namespace _1015bookstore.unittest.Controller.OrderControllerTest
{
    public class CreateOrderTest
    {
        private Mock<IOrderService> _serviceMock;
        private OrderController _sut;

        public CreateOrderTest()
        {
            _serviceMock = new Mock<IOrderService>();
            _sut = new OrderController(_serviceMock.Object);
        }

        public static IEnumerable<object[]> DataIsValid()
        {
            yield return new object[] { new List<int> { 1, 2 }, "69BD714F-9576-45BA-B5B7-F00649BE00DE" };
        }
        public static IEnumerable<object[]> DataIsInvalid()
        {
            yield return new object[] { null, null };
        }
        public static IEnumerable<object[]> ListOfCardIsEmpty()
        {
            yield return new object[] { new List<int> { }, "69BD714F-9576-45BA-B5B7-F00649BE00DE" };
        }

        [Theory]
        [MemberData(nameof(DataIsValid))]
        public async Task SetCart_ShouldReturnStatus200_WhenDataIsValid(List<int> cardids, string user_id)
        {
            //Arrange
            Guid userid = user_id == null ? Guid.Empty : Guid.Parse(user_id);
            var request = new OrderCreateRequest
            {
                cart_ids = cardids,
                user_id = userid,
            };
            var response = new ResponseService<OrderViewModel>
            {
                CodeStatus = 201,
                Status = true,
            };
            _serviceMock.Setup(x => x.CreateOrder(request)).ReturnsAsync(response);
            // Act
            var result = await _sut.CreateOrder(request) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(201);
        }

        [Theory]
        [MemberData(nameof(DataIsInvalid))]
        public async Task SetCart_ShouldReturnStatus400_WhenDataIsInvalid(List<int> cardids, string user_id)
        {
            //Arrange
            Guid userid = user_id == null ? Guid.Empty : Guid.Parse(user_id);
            var request = new OrderCreateRequest
            {
                cart_ids = cardids,
                user_id = userid,
            };
            _sut.ModelState.AddModelError("Subject", "Wrong");
            // Act
            var result = await _sut.CreateOrder(request) as BadRequestObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(400);
        }

        [Theory]
        [MemberData(nameof(DataIsInvalid))]
        public async Task SetCart_ShouldReturnStatus400_WhenListOfCardIsEmpty(List<int> cardids, string user_id)
        {
            //Arrange
            Guid userid = user_id == null ? Guid.Empty : Guid.Parse(user_id);
            var request = new OrderCreateRequest
            {
                cart_ids = cardids,
                user_id = userid,
            };
            var response = new ResponseService<OrderViewModel>
            {
                CodeStatus = 400,
                Status = false,
            };
            _serviceMock.Setup(x => x.CreateOrder(request)).ReturnsAsync(response);
            // Act
            var result = await _sut.CreateOrder(request) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(400);
        }

    }
}
