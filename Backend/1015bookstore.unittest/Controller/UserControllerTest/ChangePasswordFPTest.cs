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
    public class ChangePasswordFPTest
    {
        private readonly Mock<IUserService> _serviceMock;
        private readonly UserController _sut;

        public ChangePasswordFPTest()
        {
            _serviceMock = new Mock<IUserService>();
            _sut = new UserController(_serviceMock.Object);
        }

        [Theory]
        [InlineData("Abc@12345", "Abc@12345")]
        public async Task ChangePasswordFP_ShouldReturnStatus200_WhenDataIsValid(string password, string cofirmpassword)
        {
            //Arrange
            var request = new ChangePasswordFPRequest
            {
                password = password,
                confirmpassword = cofirmpassword
            };
            var response = new ResponseService
            {
                CodeStatus = 200,
                Status = true,
            };
            _serviceMock.Setup(x => x.ChangePasswordForgotPassword(request)).ReturnsAsync(response);
            // Act
            var result = await _sut.ChangePasswordForgotPassword(request) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("Abc@1", "Abc@1")]
        [InlineData("abc@12345", "abc@12345")]
        [InlineData("Abc12345", "Abc12345")]
        [InlineData("Abc@pnmk", "Abc@pnmk")]
        [InlineData("ABC@12345", "ABC@12345")]
        [InlineData("Abc@12345", "Adc@12345")]
        public async Task ChangePasswordFP_ShouldReturnStatus400_WhenDataIsInValid(string password, string cofirmpassword)
        {
            //Arrange
            var request = new ChangePasswordFPRequest
            {
                password = password,
                confirmpassword = cofirmpassword
            };
            _sut.ModelState.AddModelError("Subject", "Wrong");
            // Act
            var result = await _sut.ChangePasswordForgotPassword(request) as BadRequestObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(400);
        }
    }
}
