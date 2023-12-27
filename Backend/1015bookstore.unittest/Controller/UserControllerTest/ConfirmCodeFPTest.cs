using _1015bookstore.application.System.Users;
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

namespace _1015bookstore.unittest.Controller.UserControllerTest
{
    public class ConfirmCodeFPTest
    {
        private readonly Mock<IUserService> _serviceMock;
        private readonly UserController _sut;

        public ConfirmCodeFPTest()
        {
            _serviceMock = new Mock<IUserService>();
            _sut = new UserController(_serviceMock.Object);
        }
        [Theory]
        [InlineData("000000")]
        public async Task ConfirmCodeFP_ShouldReturnStatus200_WhenCodeIsValid(string code)
        {
            //Arrange
            var confirmCodeFP = new ConfirmCodeFPRequest
            {
                code = code,
                token = ""
            };
            var response = new ResponseService
            {
                CodeStatus = 200,
                Status = true,
            };
            _serviceMock.Setup(x => x.CofirmCodeForgotPassword(confirmCodeFP)).ReturnsAsync(response);
            // Act
            var result = await _sut.CofirmCodeForgotPassword(confirmCodeFP) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(200);
        }
        [Theory]
        [InlineData("000001")]
        public async Task ConfirmCodeFP_ShouldReturnStatus400_WhenCodeIsWrong(string code)
        {
            //Arrange
            var confirmCodeFP = new ConfirmCodeFPRequest
            {
                code = code,
                token = ""
            };
            var response = new ResponseService
            {
                CodeStatus = 400,
                Status = false,
            };
            _serviceMock.Setup(x => x.CofirmCodeForgotPassword(confirmCodeFP)).ReturnsAsync(response);
            // Act
            var result = await _sut.CofirmCodeForgotPassword(confirmCodeFP) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(400);
        }
        [Theory]
        [InlineData("0000000")]
        [InlineData("00000")]
        [InlineData("@00000")]
        [InlineData(null)]
        public async Task ConfirmCodeFP_ShouldReturnStatus400_WhenCodeIsInvalid(string code)
        {
            //Arrange
            var confirmCodeFP = new ConfirmCodeFPRequest
            {
                code = code,
                token = ""
            };
            _sut.ModelState.AddModelError("Subject", "Wrong");
            // Act
            var result = await _sut.CofirmCodeForgotPassword(confirmCodeFP) as BadRequestObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(400);
        }
    }
}
