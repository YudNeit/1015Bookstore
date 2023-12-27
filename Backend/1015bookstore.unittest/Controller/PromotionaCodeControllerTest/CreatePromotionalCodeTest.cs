using _1015bookstore.application.Catalog.Products;
using _1015bookstore.application.Catalog.PromotionalCodes;
using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Catalog.PromotionalCodes;
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

namespace _1015bookstore.unittest.Controller.PromotionaCodeControllerTest
{
    public class CreatePromotionalCodeTest
    {
        private readonly Mock<IPromotionalCodeService> _serviceMock;
        private readonly PromotionalCodeController _sut;

        public CreatePromotionalCodeTest()
        {
            _serviceMock = new Mock<IPromotionalCodeService>();
            _sut = new PromotionalCodeController(_serviceMock.Object);
        }

        [Theory]
        [InlineData("NEW2023", "Code NEW2023", "Code for user is discount 10%", 80, 100, "2023/12/26", "2023/12/27")]
        public async Task CreatePromotionalCode_ShouldReturnStatus201_WhenDataIsValid(string code, string name, string description, int discount_rate, int amount, DateTime fromdate, DateTime todate)
        {
            //Arrange
            var request = new PromotionalCodeCreateRequest
            {
                code = code,
                name = name,
                description = description,
                discount_rate = discount_rate,
                amount = amount,
                fromdate = fromdate,
                todate = todate
            };
            var response = new ResponseService<PromotionalCodeViewModel>
            {
                CodeStatus = 201,
                Status = true,
            };
            _serviceMock.Setup(x => x.CreatePromotionalCode(request)).ReturnsAsync(response);
            // Act
            var result = await _sut.Create(request) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(201);
        }

        [Theory]
        [InlineData(null, null, null, null, null, null, null)]
        [InlineData("NEWABC123", "Code NEW2023", "Code for user is discount 10%", 80, 100, "2023/12/26", "2023/12/27")]
        [InlineData("NEW2023", "Code NEW2023", "Code for user is discount 10%", 101, 100, "2023/12/26", "2023/12/27")]
        [InlineData("NEW2023", "Code NEW2023", "Code for user is discount 10%", 80, 0, "2023/12/26", "2023/12/27")]
        [InlineData("NEW2023", "Code NEW2023", "Code for user is discount 10%", 80, 100, "2023/12/26", "2023/12/25")]
        public async Task CreatePromotionalCode_ShouldReturnStatus400_WhenDataIsInvalid(string code, string name, string description, int discount_rate, int amount, DateTime fromdate, DateTime todate)
        {
            //Arrange
            var request = new PromotionalCodeCreateRequest
            {
                code = code,
                name = name,
                description = description,
                discount_rate = discount_rate,
                amount = amount,
                fromdate = fromdate,
                todate = todate
            };

            _sut.ModelState.AddModelError("Subject", "Wrong");
            // Act
            var result = await _sut.Create(request) as BadRequestObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(400);
        }

        [Theory]
        [InlineData("NEW2022", "Code NEW2023", "Code for user is discount 10%", 80, 100, "2023/12/26", "2023/12/27")]
        public async Task CreatePromotionalCode_ShouldReturnStatus400_WhenCodeIsUsed(string code, string name, string description, int discount_rate, int amount, DateTime fromdate, DateTime todate)
        {
            //Arrange
            var request = new PromotionalCodeCreateRequest
            {
                code = code,
                name = name,
                description = description,
                discount_rate = discount_rate,
                amount = amount,
                fromdate = fromdate,
                todate = todate
            };
            var response = new ResponseService<PromotionalCodeViewModel>
            {
                CodeStatus = 400,
                Status = false,
            };
            _serviceMock.Setup(x => x.CreatePromotionalCode(request)).ReturnsAsync(response);
            // Act
            var result = await _sut.Create(request) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(400);
        }
    }
}
