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
    public class ChangePasswordTest
    {
        private readonly Mock<IUserService> _serviceMock;
        private readonly UserController _sut;

        public ChangePasswordTest()
        {
            _serviceMock = new Mock<IUserService>();
            _sut = new UserController(_serviceMock.Object);
        }

        [Theory]
        [InlineData("Abcd1234$","Abc@12345", "Abc@12345")]
        public async Task ChangePassword_ShouldReturnStatus200_WhenDataIsValid(string oldpassword, string password, string cofirmpassword)
        {
            //Arrange
            var request = new ChangePasswordRequest
            {
                oldPassword = oldpassword,
                newPassword = password,
                confirmnewPassword = cofirmpassword
            };
            var response = new ResponseService
            {
                CodeStatus = 200,
                Status = true,
            };
            _serviceMock.Setup(x => x.ChangePassword(request)).ReturnsAsync(response);
            // Act
            var result = await _sut.ChangePassword(request) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData("Abcd1234$", "Abc@1", "Abc@1")]
        [InlineData("Abcd1234$", "abc@12345", "abc@12345")]
        [InlineData("Abcd1234$", "Abc12345", "Abc12345")]
        [InlineData("Abcd1234$", "Abc@pnmk", "Abc@pnmk")]
        [InlineData("Abcd1234$", "ABC@12345", "ABC@12345")]
        [InlineData("Abcd1234$", "Abc@12345", "Adc@12345")]
        public async Task ChangePassword_ShouldReturnStatus400_WhenDataIsInValid(string oldpassword, string password, string cofirmpassword)
        {
            //Arrange
            var request = new ChangePasswordRequest
            {
                oldPassword = oldpassword,
                newPassword = password,
                confirmnewPassword = cofirmpassword
            };
            _sut.ModelState.AddModelError("Subject", "Wrong");
            // Act
            var result = await _sut.ChangePassword(request) as BadRequestObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<BadRequestObjectResult>();
            result.StatusCode.Should().Be(400);
        }

        [Theory]
        [InlineData("Accd1234$", "Abc@12345", "Abc@12345")]
        public async Task ChangePassword_ShouldReturnStatus400_WhenOlPasswordIsWrong(string oldpassword, string password, string cofirmpassword)
        {
            //Arrange
            var request = new ChangePasswordRequest
            {
                oldPassword = oldpassword,
                newPassword = password,
                confirmnewPassword = cofirmpassword
            };
            var response = new ResponseService
            {
                CodeStatus = 400,
                Status = false,
            };
            _serviceMock.Setup(x => x.ChangePassword(request)).ReturnsAsync(response);
            // Act
            var result = await _sut.ChangePassword(request) as ObjectResult;
            // Assert
            result.Should().NotBeNull().And.BeOfType<ObjectResult>();
            result.StatusCode.Should().Be(400);
        }
    }
}
